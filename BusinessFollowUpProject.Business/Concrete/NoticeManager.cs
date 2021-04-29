using BusinessFollowUpProject.Business.Interfaces;
using BusinessFollowUpProject.DataAccess.Interfaces;
using BusinessFollowUpProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;


namespace BusinessFollowUpProject.Business.Concrete
{
    public class NoticeManager : INoticeService
    {
        private readonly INotice _inotice;
        public NoticeManager(INotice inotice)
        {
            _inotice = inotice;
        }

        public void Delete(Notice table)
        {
             _inotice.Delete(table);
        }

        public List<Notice> GetAll()
        {
            return _inotice.GetAll();
        }

        public Notice GetId(int id)
        {
            return _inotice.GetId(id);
        }

        public int GetUnReadNoticeCountAppUserId(int AppUserId)
        {
            return _inotice.GetUnReadNoticeCountAppUserId(AppUserId);
        }

        public List<Notice> GetUnreads(int AppUserId)
        {
            return _inotice.GetUnreads(AppUserId);
        }

        public void Save(Notice table)
        {
             _inotice.Save(table);
        }

        public void Update(Notice table)
        {
            _inotice.Update(table);
        }
    }
}
