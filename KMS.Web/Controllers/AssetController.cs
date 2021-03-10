using KMS.DB.Data;
using KMS.DB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMS.Web.Controllers
{
    public class AssetController : Controller
    {
        private readonly MySQLContext _db;
        public AssetController(MySQLContext db)
        {
            _db = db;
        }
        public IActionResult ListAllKey(string _txtSearch)
        {
            List<KMS_MSTASSET> LstAsset = new List<KMS_MSTASSET>();
            if (!string.IsNullOrEmpty(_txtSearch))
            {

            }
            else
            {
                LstAsset = _db.KMS_MSTASSET.ToList();
            }
            return View(LstAsset);
        }
        public IActionResult Edit(int _AssetId)
        {
            KMS_MSTASSET asset = new KMS_MSTASSET();
            asset = _db.KMS_MSTASSET.Find(_AssetId);
            return View(asset);
        }
        public IActionResult Save(KMS_MSTASSET _Asset)
        {
            return RedirectToAction("List");
        }
        public IActionResult Disiable(int _AssetId)
        {
            KMS_MSTASSET asset = new KMS_MSTASSET();
            asset = _db.KMS_MSTASSET.Find(_AssetId);
            asset.IsActive = false;
            _db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult SearchAssetKey(string _txtSearch)
        {
            List<KMS_MSTASSET> LstAsset = new List<KMS_MSTASSET>();
            LstAsset = _db.KMS_MSTASSET
                        .Where(o => o.Asset_Code.Contains(_txtSearch) ||
                            o.Asset_Desc.Contains(_txtSearch) ||
                            o.Key.Key_Code.Contains(_txtSearch) ||
                            o.Key.Key_Desc.Contains(_txtSearch)
                        ).ToList();
            if (LstAsset.Count() > 0)
            {
                ViewBag.Result = string.Format("Find {0} List", LstAsset.Count());
            }
            else
            {
                ViewBag.Result = "Data not found.";                
            }
            return View(LstAsset);
        }
    }
}
