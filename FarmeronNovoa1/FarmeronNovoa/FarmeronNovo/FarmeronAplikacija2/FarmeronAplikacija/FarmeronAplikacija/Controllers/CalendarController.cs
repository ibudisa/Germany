using System;
using System.Collections.Generic; 
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DHTMLX.Scheduler;
using DHTMLX.Common;
using DHTMLX.Scheduler.Data;
using FarmeronAplikacija.Models;
namespace FarmeronAplikacija.Controllers
{
      

        public class CalendarController : Controller
        {
            //
            // GET: /Calendar/

            public ActionResult Index()
            {
                var sched = new DHXScheduler(this);
                sched.Skin = DHXScheduler.Skins.Terrace;
                sched.LoadData = true;
                sched.EnableDataprocessor = true;
                sched.InitialDate = new DateTime(2015, 7, 5);
                return View(sched);
            }

            public ContentResult Data()
            {
                return (new SchedulerAjaxData(
                    new ActionsDataContext().Aktivnostis
                    .Select(e => new { e.id, e.text, e.start_date, e.end_date })
                    )
                    );
            }

           public ContentResult Save(int? id, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);
            var changedEvent = (Aktivnosti)DHXEventsHelper.Bind(typeof(Aktivnosti), actionValues);
            var data = new ActionsDataContext();
 
            try
            {
                switch (action.Type)
                {
                    case DataActionTypes.Insert: // define here your Insert logic
                        data.Aktivnostis.InsertOnSubmit(changedEvent);
 
                        break;
                    case DataActionTypes.Delete: // define here your Delete logic
                        changedEvent = data.Aktivnostis.SingleOrDefault(ev => ev.id == action.SourceId);
                        data.Aktivnostis.DeleteOnSubmit(changedEvent);
                        break;
                    default:// "update" // define here your Update logic
                        var eventToUpdate = data.Aktivnostis.SingleOrDefault(ev => ev.id == action.SourceId);
                        DHXEventsHelper.Update(eventToUpdate, changedEvent, new List<string>() { "id" });//update all properties, except for id
                        break;
                }
                data.SubmitChanges();
                action.TargetId = changedEvent.id;
            }
            catch (Exception a)
            {
                action.Type = DataActionTypes.Error;
            }
            return (new AjaxSaveResponse(action));
        }
    
           
        }
}