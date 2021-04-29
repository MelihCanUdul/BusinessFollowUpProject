using BusinessFollowUpProject.Business.Interfaces;
using BusinessFollowUpProject.Entities.Concrete;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessFollowUpProject.Web.TagHelpers
{
    [HtmlTargetElement("getTaskAppUserId")]
    public class TaskAppUserIdTagHelper: TagHelper
    {
        private readonly ITaskService _taskService;
        public TaskAppUserIdTagHelper(ITaskService taskService)
        {
            _taskService = taskService;

        }
        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<Task> tasks=_taskService.GetAppUserId(AppUserId);
            int completed = tasks.Where(I => I.Status).Count();
            int worktaskcount = tasks.Where(I => !I.Status).Count();
            string htmlString = $"<strong>Tamamladığı görev sayısı : </strong>{completed}<br><strong>Üstünde çalıştığı görev sayısı : </strong>{worktaskcount}";
            output.Content.SetHtmlContent(htmlString);

        }

    }
}
