using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Countersoft.Gemini.Commons.Entity;
using Countersoft.Gemini.Extensibility.Events;
using Countersoft.Gemini.Commons.Dto;
using Countersoft.Gemini.Extensibility.Apps;

namespace AutoFollower
{
    [AppType(AppTypeEnum.Event),
    AppGuid("6A6D919B-EC37-41BC-A398-AF755C87DE41"),
    AppName("Auto Follower"),
    AppDescription("Automatically adds the item creator and resources as followers")]
    public class AutoFollower : IIssueBeforeListener
    {
        public Issue BeforeCreate(IssueEventArgs args)
        {
            var resources = args.Entity.GetResources();

            resources.RemoveAll(r => r == 0);

            args.Entity.AddWatchers(resources);

            args.Entity.AddWatcher(args.Entity.ReportedBy);

            return args.Entity;
        }

        public Issue BeforeUpdate(IssueEventArgs args)
        {
            var resources = args.Entity.GetResources();

            var watchers = args.Entity.GetWatchers();

            var missingResources = resources.FindAll(r => !watchers.Contains(r) && r != 0);

            if (missingResources.Count > 0)
            {
                args.Entity.AddWatchers(missingResources);
            }

            return args.Entity;
        }

        public Issue BeforeDelete(IssueEventArgs args)
        {
            return args.Entity;
        }

        public IssueComment BeforeComment(IssueCommentEventArgs args)
        {
            return args.Entity;
        }

        public Issue BeforeStatusChange(IssueEventArgs args)
        {
            return args.Entity;
        }

        public Issue BeforeResolutionChange(IssueEventArgs args)
        {
            return args.Entity;
        }

        public Issue BeforeAssign(IssueEventArgs args)
        {
            return args.Entity;
        }

        public Issue BeforeClose(IssueEventArgs args)
        {
            return args.Entity;
        }

        public Issue BeforeWatcherAdd(IssueEventArgs args)
        {
            return args.Entity;
        }

        public string Description { get; set; }
        public string Name { get; set; }
        public string AppGuid { get; set; }

        public IssueDto BeforeCreateFull(IssueDtoEventArgs args)
        {
            return args.Issue;
        }

        public IssueDto BeforeUpdateFull(IssueDtoEventArgs args)
        {
            return args.Issue;
        }

        public IssueDto BeforeIssueCopy(IssueDtoEventArgs args)
        {
            return args.Issue;
        }

        public IssueDto CopyIssueComplete(IssueDtoEventArgs args)
        {
            return args.Issue;
        }
    }
}
