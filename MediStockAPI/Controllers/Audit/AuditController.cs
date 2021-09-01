using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;
using System.Web.Cors;

namespace MediStockAPI.Controllers
{
    public class AuditController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getAuditLog")]

        public IHttpActionResult getAuditLog()
        {
            try
            {
                List<AuditVM> outputAudits = new List<AuditVM>();

                var storedAudits = db.AuditLogs.ToList();

                foreach (var storedAudit in storedAudits)
                {
                    AuditVM audit = new AuditVM();

                    audit.AuditID = (int)storedAudit.AuditID;
                    audit.AuditDateTime = (DateTime)storedAudit.AuditDateTime;
                    audit.TableName = storedAudit.TableName;
                    audit.Action = storedAudit.Action;
                    audit.UserID = storedAudit.UserID;
                    audit.MachineName = storedAudit.MachineName;
                    audit.IDName = storedAudit.IDName;
                    audit.OldData = storedAudit.OldData;
                    audit.NewData = storedAudit.NewData;

                    outputAudits.Add(audit);
                }

                return Ok(outputAudits);

            }
            catch (Exception err)
            {

                return BadRequest((err).ToString());
            }
        }

        [HttpGet]
        [Route("getFilteredAudits")]
        public IHttpActionResult getFilteredAudits(string searchAction)
        {

            try
            {
                var audits = db.AuditLogs.ToList(); 
                List<AuditVM> AuditList = new List<AuditVM>();

                foreach (var audit in audits)
                {

                    if (audit.Action == searchAction)
                    {
                        AuditVM auditItem = new AuditVM();

                        auditItem.AuditID = (int)audit.AuditID;
                        auditItem.AuditDateTime = (DateTime)audit.AuditDateTime;
                        auditItem.TableName = audit.TableName;
                        auditItem.Action = audit.Action;
                        auditItem.UserID = audit.UserID;
                        auditItem.MachineName = audit.MachineName;
                        auditItem.IDName = audit.IDName;
                        auditItem.OldData = audit.OldData;
                        auditItem.NewData = audit.NewData;

                        AuditList.Add(auditItem);
                    }

                }

                return Ok(AuditList);
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }
    }
}
