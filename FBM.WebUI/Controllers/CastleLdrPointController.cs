using FBM.Core.Resource;
using FBM.Data.API;
using FBM.Data.Entity.Station;
using FBM.Data.Enum;
using FBM.WebUI.Models.CastleLdrPointM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FBM.WebUI.Controllers
{
    public class CastleLdrPointController : BaseController
    {
        public ActionResult Index()
        {
            CastleLdrPointVM vm = new CastleLdrPointVM();
            vm.List = ClientServiceProxy.CastleLdrPointService().Get();
            return View(vm);
        }
        public PartialViewResult _CastleLdrPointList()
        {
            List<CastleLdrPoint> res = ClientServiceProxy.CastleLdrPointService().Get();
            return PartialView(res);
        }
        public ActionResult Details(Guid id)
        {
            CastleLdrPoint vm = ClientServiceProxy.CastleLdrPointService().Get(id);
            if (vm == null)
            {
                return RedirectToAction("index");
            }
            return View(vm);
        }

        public ActionResult Edit(Guid id)
        {
            CastleLdrPoint vm = ClientServiceProxy.CastleLdrPointService().Get(id);
            if (vm == null)
            {
                return RedirectToAction("index");
            }
            FillViewBag();
            return View(vm);
        }

        private void FillViewBag()
        {
            ViewBag.CastleList = ClientServiceProxy.CastleService().Get().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CastleLdrPoint entity)
        {
            try
            {
                ClientServiceProxy.CastleLdrPointService().Put(entity.Id, entity);
            }
            catch (Exception)
            {
                ShowMessage(Helper.MessageType.Warning, Resources.ErrorActionUnsuccess, 5);
                FillViewBag();
                return View(entity);
            }
            return RedirectToAction("Details", new { id = entity.Id });
        }

        public ActionResult Create()
        {
            CastleLdrPointAddVM vm = new CastleLdrPointAddVM();
            FillViewBag();
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CastleLdrPointAddVM vm)
        {
            try
            {
                CastleLdrPoint xPoint = new CastleLdrPoint()
                {
                    CastleId = vm.CastleId,
                    Axis = Data.Enum.Axis.X,
                    StartPoint = vm.XStartPoint,
                    EndPoint = vm.XEndPoint
                };
                CastleLdrPoint yPoint = new CastleLdrPoint()
                {
                    CastleId = vm.CastleId,
                    Axis = Data.Enum.Axis.Y,
                    StartPoint = vm.YStartPoint,
                    EndPoint = vm.YEndPoint
                };

                xPoint = ClientServiceProxy.CastleLdrPointService().Post(xPoint);
                yPoint = ClientServiceProxy.CastleLdrPointService().Post(yPoint);
            }
            catch (Exception)
            {
                ShowMessage(Helper.MessageType.Warning, Resources.ErrorActionUnsuccess, 5);
                FillViewBag();
                return View(vm);
            }
            return RedirectToAction("index");
        }

        public ActionResult FastCreate()
        {
            CastleLdrPointFastAddVM vm = new CastleLdrPointFastAddVM();
            ViewBag.StationList = ClientServiceProxy.StationService().Get().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FastCreate(CastleLdrPointFastAddVM vm)
        {
            try
            {
                int castleNo = ClientServiceProxy.CastleService().Get().Max(x => x.CastleNo);
                Station station = ClientServiceProxy.StationService().Get().First(x => x.Id == vm.StationID);

                if (castleNo != 0)
                {
                    castleNo += 1;
                }
                Castle c1b = CreateCastle_(castleNo, station.Id, Floor.Bottom, CastlePosition.Castle1,vm.WallPosition);
                castleNo += 1;
                Castle c1t = CreateCastle_(castleNo, station.Id, Floor.Top, CastlePosition.Castle1, vm.WallPosition);

                castleNo += 1;
                Castle c2b = CreateCastle_(castleNo, station.Id, Floor.Bottom, CastlePosition.Castle2, vm.WallPosition);
                castleNo += 1;
                Castle c2t = CreateCastle_(castleNo, station.Id, Floor.Top, CastlePosition.Castle2, vm.WallPosition);

                castleNo += 1;
                Castle c3b = CreateCastle_(castleNo, station.Id, Floor.Bottom, CastlePosition.Castle3, vm.WallPosition);
                castleNo += 1;
                Castle c3t = CreateCastle_(castleNo, station.Id, Floor.Top, CastlePosition.Castle3, vm.WallPosition);

                castleNo += 1;
                Castle c4b = CreateCastle_(castleNo, station.Id, Floor.Bottom, CastlePosition.Castle4, vm.WallPosition);
                castleNo += 1;
                Castle c4t = CreateCastle_(castleNo, station.Id, Floor.Top, CastlePosition.Castle4, vm.WallPosition);

                castleNo += 1;
                Castle c5b = CreateCastle_(castleNo, station.Id, Floor.Bottom, CastlePosition.Castle5, vm.WallPosition);
                castleNo += 1;
                Castle c5t = CreateCastle_(castleNo, station.Id, Floor.Top, CastlePosition.Castle5, vm.WallPosition);

                castleNo += 1;
                Castle c6b = CreateCastle_(castleNo, station.Id, Floor.Bottom, CastlePosition.Castle6, vm.WallPosition);
                castleNo += 1;
                Castle c6t = CreateCastle_(castleNo, station.Id, Floor.Top, CastlePosition.Castle6, vm.WallPosition);

                castleNo += 1;
                Castle c7b = CreateCastle_(castleNo, station.Id, Floor.Bottom, CastlePosition.Castle7, vm.WallPosition);
                castleNo += 1;
                Castle c7t = CreateCastle_(castleNo, station.Id, Floor.Top, CastlePosition.Castle7, vm.WallPosition);

                castleNo += 1;
                Castle c8b = CreateCastle_(castleNo, station.Id, Floor.Bottom, CastlePosition.Castle8, vm.WallPosition);
                castleNo += 1;
                Castle c8t = CreateCastle_(castleNo, station.Id, Floor.Top, CastlePosition.Castle8, vm.WallPosition);

                castleNo += 1;
                Castle c9b = CreateCastle_(castleNo, station.Id, Floor.Bottom, CastlePosition.Castle9, vm.WallPosition);
                castleNo += 1;
                Castle c9t = CreateCastle_(castleNo, station.Id, Floor.Top, CastlePosition.Castle9, vm.WallPosition);

                CreateLdrPoint_(c1b, vm.Data4, vm.Data5, vm.Data2, vm.Data3);
                CreateLdrPoint_(c1t, vm.Data4, vm.Data5, vm.Data1, vm.Data2);

                CreateLdrPoint_(c2b, vm.Data5, vm.Data6, vm.Data2, vm.Data3);
                CreateLdrPoint_(c2t, vm.Data5, vm.Data6, vm.Data1, vm.Data2);

                CreateLdrPoint_(c3b, vm.Data6, vm.Data7, vm.Data2, vm.Data3);
                CreateLdrPoint_(c3t, vm.Data6, vm.Data7, vm.Data1, vm.Data2);

                CreateLdrPoint_(c4b, vm.Data7, vm.Data8, vm.Data2, vm.Data3);
                CreateLdrPoint_(c4t, vm.Data7, vm.Data8, vm.Data1, vm.Data2);

                CreateLdrPoint_(c5b, vm.Data8, vm.Data9, vm.Data2, vm.Data3);
                CreateLdrPoint_(c5t, vm.Data8, vm.Data9, vm.Data1, vm.Data2);

                CreateLdrPoint_(c6b, vm.Data9, vm.Data10, vm.Data2, vm.Data3);
                CreateLdrPoint_(c6t, vm.Data9, vm.Data10, vm.Data1, vm.Data2);

                CreateLdrPoint_(c7b, vm.Data10, vm.Data11, vm.Data2, vm.Data3);
                CreateLdrPoint_(c7t, vm.Data10, vm.Data11, vm.Data1, vm.Data2);

                CreateLdrPoint_(c8b, vm.Data11, vm.Data12, vm.Data2, vm.Data3);
                CreateLdrPoint_(c8t, vm.Data11, vm.Data12, vm.Data1, vm.Data2);

                CreateLdrPoint_(c9b, vm.Data12, vm.Data13, vm.Data2, vm.Data3);
                CreateLdrPoint_(c9t, vm.Data12, vm.Data13, vm.Data1, vm.Data2);
            }
            catch (Exception)
            {
                ShowMessage(Helper.MessageType.Warning, Resources.ErrorActionUnsuccess, 5);
                ViewBag.StationList = ClientServiceProxy.StationService().Get().Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
                return View(vm);
            }
            return RedirectToAction("index");
        }

        private Castle CreateCastle_(int castleNo, Guid stationid, Floor floor, CastlePosition castlePosition,WallPosition wp)
        {
            Castle castle = new Castle()
            {
                CastleNo = castleNo,
                CastleFloor = floor,
                CastlePosition = castlePosition,
                StationId = stationid,
                WallPosition = wp
            };
            castle = ClientServiceProxy.CastleService().Post(castle);
            return castle;
        }

        private void CreateLdrPoint_(Castle castle, int x1, int x2, int y1, int y2)
        {
            CastleLdrPoint xpoint = new CastleLdrPoint()
            {
                CastleId = castle.Id,
                Axis = Data.Enum.Axis.X,
                StartPoint = x1,
                EndPoint = x2
            };
            CastleLdrPoint ypoint = new CastleLdrPoint()
            {
                CastleId = castle.Id,
                Axis = Data.Enum.Axis.Y,
                StartPoint = y1,
                EndPoint = y2
            };

            xpoint = ClientServiceProxy.CastleLdrPointService().Post(xpoint);
            ypoint = ClientServiceProxy.CastleLdrPointService().Post(ypoint);
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            try
            {
                ClientServiceProxy.CastleLdrPointService().Delete(id);
            }
            catch (Exception)
            {
                ShowMessage(Helper.MessageType.Warning, Resources.ErrorActionUnsuccess, 5);
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("index");
        }
    }
}