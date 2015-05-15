using System;
using DDDScrum;
using Xunit;

namespace DDDScrumFacts
{
    public class BacklogItemFact
    {
        [Fact]
        public void should_commit_a_product_back_log_item_to_a_sprint()
        {
            var product = new Product("ScrumDDD");
            var sprint = product.Schedule("Sprint1", new DateTime(2015, 1, 1), new DateTime(2015, 1, 15));

            var backLogItem = product.Plan("this is a story");

            backLogItem.CommitTo(sprint);
            Assert.Equal(sprint.Id, backLogItem.SprintId);
            Assert.Equal(BackLogItemStatus.Commited, backLogItem.BackLogItemStatus);
        }
        
        [Fact]
        public void should_calc_back_log_item_priority()
        {
            var product = new Product("ScrumDDD");
            var backLogItem = product.Plan("this is a story");
            var businessPriority = new BusinessPriority(3, 2, 2);

            backLogItem.Assign(businessPriority);

            Assert.Equal(2.17, backLogItem.BusinessPriority.Priority);
        }

        [Fact]
        public void should_define_a_task_for_a_back_log_item()
        {
            var product = new Product("ScrumDDD");
            var backLogItem = product.Plan("this is a story");

            backLogItem.DefineTask("this is a task", 10);

            var definedTask = backLogItem.Tasks[0];
            Assert.Equal(backLogItem.Id, definedTask.BackLogItemId);
            Assert.Equal("this is a task", definedTask.TaskName);
            Assert.Equal(10, definedTask.RemainingHour);
        }

        [Fact]
        public void should_backlogitemstatus_to_done_given_all_tasks_in_backlogItem_remaininghour_is_0()
        {
            var product = new Product("ScrumDDD");
            var backLogItem = product.Plan("this is a story");

            var defineTask1 = backLogItem.DefineTask("this is a task 1", 10);
            var defineTask2 = backLogItem.DefineTask("this is a task 2", 11);

            backLogItem.EstimateTaskHourRemaining(defineTask1.Id, 0);
            backLogItem.EstimateTaskHourRemaining(defineTask2.Id, 0);

            Assert.Equal(BackLogItemStatus.Done, backLogItem.BackLogItemStatus);
        }
    }
}
