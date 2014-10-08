using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using KSEPM.Common.Enums;
using KSEPM.Web.Database.Entities;
using Microsoft.Ajax.Utilities;

namespace KSEPM.Web.Database
{
    internal class ChairDbInitializer
    {
        private static KSEPMDbContext _context;

        public static void Initialize(KSEPMDbContext context)
        {
            _context = context;
            var chairLines = InitializeChairLines();
            //InitializeChairsOptions();
            InitializeChairs(chairLines);
            InitializeSellPoints();
        }

        private static List<ChairLine> InitializeChairLines()
        {
            var chairLines = new List<ChairLine>
            {
                new ChairLine
                {
                    Name = ChairLineType.Luxury,
                    ChairMultiply = 1.5,
                    OptionMultiply = 0.7
                },
                new ChairLine
                {
                    Name = ChairLineType.Premium,
                    ChairMultiply = 1.2,
                    OptionMultiply = 0.9
                },
                new ChairLine
                {
                    Name = ChairLineType.Universal,
                    ChairMultiply = 1.0,
                    OptionMultiply = 1.1
                },
                new ChairLine
                {
                    Name = ChairLineType.Junior,
                    ChairMultiply = 1.1,
                    OptionMultiply = 1.2
                },
                new ChairLine
                {
                    Name = ChairLineType.Baby,
                    ChairMultiply = 1.1,
                    OptionMultiply = 1.2
                }
            };

            _context.ChairLines.AddRange(chairLines);

            _context.SaveChanges();
            return chairLines;
        }

        private static Dictionary<string, Chair> InitializeChairs(List<ChairLine> chairLines)
        {
            var chairList = new List<Chair>();

            /* LUXURY LINE*/

            var chairDiamond = new Chair
            {
                Name = ChairName.Diamond,
                Price = 11500,
                ChairLine = chairLines.Find(x => x.Name == ChairLineType.Luxury),
                ChairOptions = new Collection<ChairOption>
                {
                    Cross_Wooden_Basic, Mechanism_Slander_Basic, Mechanism_StopSupport_150, Onvay_StitchDesign_Basic,
                    Onvay_logo_700, Upholstery_Leather_5200, Upholstery_PerfLeather_1200, Upholstery_Antara_Basic
                }
            };

            /* PREMIUM LINE*/

            var chairMonarch = new Chair
            {
                Name = ChairName.Monarch,
                Price = 9200,
                ChairLine = chairLines.Find(x => x.Name == ChairLineType.Premium),
                ChairOptions = new Collection<ChairOption>
                {
                    Cross_ChromeCoated_Basic, HeadRest_AngleHeight_Basic, Mechanism_Slander_Basic, Mechanism_RingBase_400, Mechanism_StopSupport_150,
                    Onvay_StitchAristo_Basic, Onvay_Swaroski_1500, Onvay_logo_700, Upholstery_Leather_2500, Upholstery_PerfLeather_600, Upholstery_Antara_Basic
                }
            };
            var chairJet = new Chair
            {
                Name = ChairName.Jet,
                Price = 6600,
                ChairLine = chairLines.Find(x => x.Name == ChairLineType.Premium),
                ChairOptions = new Collection<ChairOption>
                {
                    Cross_ChromeCoated_Basic, HeadRest_AngleHeight_Basic, Mechanism_Slander_Basic, Mechanism_RingBase_400, Mechanism_StopSupport_150,
                    Onvay_StitchQuatro_1200, Onvay_Swaroski_1500, Onvay_logo_700, Upholstery_Leather_2500, Upholstery_PerfLeather_600, Upholstery_Antara_Basic
                }
            };
            var chairGrande = new Chair
            {
                Name = ChairName.Grande,
                Price = 5600,
                ChairLine = chairLines.Find(x => x.Name == ChairLineType.Premium),
                ChairOptions = new Collection<ChairOption>
                {
                    Cross_ChromeCoated_Basic, HeadRest_AngleHeight_Basic, Mechanism_Slander_Basic, Mechanism_RingBase_400, Mechanism_StopSupport_150,
                    Onvay_StitchDesign_1200, Onvay_Swaroski_1500, Onvay_logo_700, Upholstery_Leather_2500, Upholstery_PerfLeather_600, Upholstery_Antara_Basic
                }
            };
            var chairRoyal = new Chair
            {
                Name = ChairName.Royal,
                Price = 4800,
                ChairLine = chairLines.Find(x => x.Name == ChairLineType.Premium),
                ChairOptions = new Collection<ChairOption>
                {
                    Cross_Poliamid_Basic, Cross_ChromeCoated_400, HeadRest_AngleHeight_Basic, Mechanism_Slander_Basic, Mechanism_RingBase_400, Mechanism_StopSupport_150,
                    Onvay_StitchDesign_1200, Onvay_Swaroski_1500, Onvay_logo_700, Upholstery_Leather_2500, Upholstery_PerfLeather_600, Upholstery_Antara_Basic
                }
            };
            var chairBusiness = new Chair
            {
                Name = ChairName.Business,
                Price = 4300,
                ChairLine = chairLines.Find(x => x.Name == ChairLineType.Premium),
                ChairOptions = new Collection<ChairOption>
                {
                    Cross_Poliamid_Basic, Cross_ChromeCoated_400, HeadRest_AngleHeight_600, Mechanism_Slander_Basic, Mechanism_RingBase_400, Mechanism_StopSupport_150,
                    Onvay_StitchDesign_1200, Onvay_Swaroski_1500, Onvay_logo_700, Upholstery_Leather_2500, Upholstery_PerfLeather_600, Upholstery_Antara_Basic
                }
            };
            var chairImperial = new Chair
            {
                Name = ChairName.Imperial,
                Price = 3800,
                ChairLine = chairLines.Find(x => x.Name == ChairLineType.Premium),
                ChairOptions = new Collection<ChairOption>
                {
                    Cross_Poliamid_Basic, Cross_ChromeCoated_400, Mechanism_Slander_Basic, Mechanism_RingBase_400, Mechanism_StopSupport_150,
                    Onvay_StitchFashion_1200, Onvay_Swaroski_1500, Onvay_logo_700, Upholstery_Leather_2500, Upholstery_PerfLeather_600, Upholstery_Antara_Basic
                }
            };

            /* UNIVERSAL LINE */

            var chairVictory = new Chair
            {
                Name = ChairName.Victory,
                Price = 2900,
                ChairLine = chairLines.Find(x => x.Name == ChairLineType.Universal),
                ChairOptions = new Collection<ChairOption>
                {
                    Cross_Poliamid_Basic, Cross_ChromeCoated_400, HeadRest_AngleHeight_500, Mechanism_Slander_Basic, Mechanism_RingBase_400, Mechanism_StopSupport_150,
                    Onvay_StitchQuatro_1200, Onvay_Swaroski_1200, Onvay_logo_700, Upholstery_Leather_2000, Upholstery_PerfLeather_600, Upholstery_Antara_Basic
                }
            };
            var chairPyramid = new Chair
            {
                Name = ChairName.Pyramid,
                Price = 3400,
                ChairLine = chairLines.Find(x => x.Name == ChairLineType.Universal),
                ChairOptions = new Collection<ChairOption>
                {
                    Cross_Poliamid_Basic, Cross_ChromeCoated_400, Mechanism_Slander_Basic, Mechanism_RingBase_400, Mechanism_StopSupport_150,
                    Onvay_StitchQuatro_1200, Onvay_Swaroski_1200, Onvay_logo_700, Upholstery_Leather_2000, Upholstery_PerfLeather_600, Upholstery_Antara_Basic
                }
            };
            var chairGalaxy = new Chair
            {
                Name = ChairName.Galaxy,
                Price = 2600,
                ChairLine = chairLines.Find(x => x.Name == ChairLineType.Universal),
                ChairOptions = new Collection<ChairOption>
                {
                    Cross_Poliamid_Basic, Cross_ChromeCoated_400, Mechanism_Slander_Basic, Mechanism_RingBase_400, Mechanism_StopSupport_150,
                    Onvay_StitchZeta_1200, Onvay_Swaroski_1200, Onvay_logo_700, Upholstery_Leather_2000, Upholstery_PerfLeather_600, Upholstery_Antara_Basic
                }
            };
            var chairElegance = new Chair
            {
                Name = ChairName.Elegance,
                Price = 2400,
                ChairLine = chairLines.Find(x => x.Name == ChairLineType.Universal),
                ChairOptions = new Collection<ChairOption>
                {
                    Cross_Poliamid_Basic, Cross_ChromeCoated_400, HeadRest_AngleHeight_400, Mechanism_Slander_Basic, Mechanism_RingBase_400, Mechanism_StopSupport_150,
                    Onvay_StitchDesign_1200, Onvay_Swaroski_1200, Onvay_logo_700, Upholstery_Leather_2000, Upholstery_PerfLeather_600, Upholstery_Antara_Basic
                }
            };
            var chairClassicMaxi = new Chair
            {
                Name = ChairName.ClassicMaxi,
                Price = 2600,
                ChairLine = chairLines.Find(x => x.Name == ChairLineType.Universal),
                ChairOptions = new Collection<ChairOption>
                {
                    Cross_Poliamid_Basic, Cross_ChromeCoated_400, HeadRest_AngleHeight_400, Mechanism_Slander_Basic, Mechanism_RingBase_400, Mechanism_StopSupport_150,
                    Onvay_Swaroski_1200, Onvay_logo_700, Upholstery_Leather_2000, Upholstery_PerfLeather_600, Upholstery_Antara_Basic
                }
            };
            var chairClassic = new Chair
            {
                Name = ChairName.Classic,
                Price = 2300,
                ChairLine = chairLines.Find(x => x.Name == ChairLineType.Universal),
                ChairOptions = new Collection<ChairOption>
                {
                    Cross_Poliamid_Basic, Cross_ChromeCoated_400, HeadRest_Angle_400, Mechanism_Basic_Basic, Mechanism_RingBase_400, Mechanism_StopSupport_150,
                    Onvay_Swaroski_1200, Onvay_logo_700, Upholstery_Leather_2000, Upholstery_PerfLeather_600, Upholstery_Antara_Basic
                }
            };

            /* JUNIOR LINE */

            var chairFly = new Chair
            {
                Name = ChairName.Fly,
                Price = 4000,
                ChairLine = chairLines.Find(x => x.Name == ChairLineType.Junior),
                ChairOptions = new Collection<ChairOption>
                {
                    Cross_Poliamid_Basic, Cross_ChromeCoated_400, HeadRest_Angle_Basic, Mechanism_Basic_Basic, Mechanism_RingBase_400, Mechanism_StopSupport_150,
                    Onvay_Swaroski_1200, Onvay_logo_700, Upholstery_Leather_1700, Upholstery_PerfLeather_600, Upholstery_Antara_Basic
                }
            };
            var chairTrio = new Chair
            {
                Name = ChairName.Trio,
                Price = 2900,
                ChairLine = chairLines.Find(x => x.Name == ChairLineType.Junior),
                ChairOptions = new Collection<ChairOption>
                {
                    Cross_Poliamid_Basic, Cross_ChromeCoated_400, HeadRest_Angle_Basic, Mechanism_Basic_Basic, Mechanism_RingBase_400, Mechanism_StopSupport_150,
                    Onvay_Swaroski_1200, Onvay_logo_700, Upholstery_Leather_1700, Upholstery_PerfLeather_600, Upholstery_Antara_Basic
                }
            };

            /* BABY LINE */

            var chairKids = new Chair
            {
                Name = ChairName.Kids,
                Price = 2200,
                ChairLine = chairLines.Find(x => x.Name == ChairLineType.Baby),
                ChairOptions = new Collection<ChairOption>
                {
                    Cross_Poliamid_Basic, Cross_ChromeCoated_400, Mechanism_Basic_Basic, Mechanism_RingBase_400, Mechanism_StopSupport_150,
                    Onvay_Swaroski_1200, Onvay_logo_700, Upholstery_Leather_1700, Upholstery_PerfLeather_600, Upholstery_Antara_Basic
                }
            };

            chairList.Add(chairDiamond);

            chairList.Add(chairMonarch);
            chairList.Add(chairJet);
            chairList.Add(chairGrande);
            chairList.Add(chairRoyal);
            chairList.Add(chairBusiness);
            chairList.Add(chairImperial);

            chairList.Add(chairVictory);
            chairList.Add(chairPyramid);
            chairList.Add(chairGalaxy);
            chairList.Add(chairElegance);
            chairList.Add(chairClassicMaxi);
            chairList.Add(chairClassic);

            chairList.Add(chairFly);
            chairList.Add(chairTrio);

            chairList.Add(chairKids);

            _context.Chairs.AddRange(chairList);

            _context.SaveChanges();

            return null;
        }

        private static void InitializeSellPoints()
        {
            var sellPoints = new List<SellPoint>
            {
                new SellPoint
                {
                    Country = Country.Ukraine,
                    City = City.Kiev,
                    PointType = SellPointType.Outside,
                    PointName = SellPointName.DomMebeli
                },
                new SellPoint
                {
                    Country = Country.Ukraine,
                    City = City.Kiev,
                    PointType = SellPointType.Outside,
                    PointName = SellPointName.DreamTown
                },
                new SellPoint
                {
                    Country = Country.Ukraine,
                    City = City.Kiev,
                    PointType = SellPointType.Outside,
                    PointName = SellPointName.Forum
                },
                new SellPoint
                {
                    Country = Country.Ukraine,
                    City = City.Kiev,
                    PointType = SellPointType.Outside,
                    PointName = SellPointName.Arax
                },
                new SellPoint
                {
                    Country = Country.Ukraine,
                    City = City.Kiev,
                    PointType = SellPointType.Outside,
                    PointName = SellPointName.Darinok
                },
                new SellPoint
                {
                    Country = Country.Ukraine,
                    City = City.Kiev,
                    PointType = SellPointType.Outside,
                    PointName = SellPointName.VashDom
                },
                new SellPoint
                {
                    Country = Country.Ukraine,
                    City = City.Lvov,
                    PointType = SellPointType.Outside,
                    PointName = SellPointName.ThreeSlona
                },
                new SellPoint
                {
                    Country = Country.Ukraine,
                    City = City.Odessa,
                    PointType = SellPointType.Outside,
                    PointName = SellPointName.SixElement
                },
            };

            _context.SellPoints.AddRange(sellPoints);
        }

        private const int CROSS_CHROME_400 = 400;
        private const int HEADREST_ANGLE_400 = 400;
        private const int HEADREST_ANGLE_HEIGHT_600 = 600;
        private const int HEADREST_ANGLE_HEIGHT_500 = 500;
        private const int HEADREST_ANGLE_HEIGHT_400 = 400;
        private const int MECHANISM_RING_BASE_400 = 400;
        private const int MECHANISM_STOP_SUPPORT_150 = 150;
        private const int ONVAY_STITCH_1200 = 1200;
        private const int ONVAY_SWAROVSKI_1500 = 1500;
        private const int ONVAY_SWAROVSKI_1200 = 1200;
        private const int ONVAY_LOGO_700 = 700;
        private const int UPHOLSTERY_LEATHER_5200 = 5200;
        private const int UPHOLSTERY_LEATHER_2500 = 2500;
        private const int UPHOLSTERY_LEATHER_2000 = 2000;
        private const int UPHOLSTERY_LEATHER_1700 = 1700;
        private const int UPHOLSTERY_PERF_LEATHER_1200 = 1200;
        private const int UPHOLSTERY_PERF_LEATHER_600 = 600;

        public static ChairOption Cross_Poliamid_Basic = GenerateChairOption(ChairOptionType.Cross, ChairOptionName.Polyamide, true);
        public static ChairOption Cross_ChromeCoated_Basic = GenerateChairOption(ChairOptionType.Cross, ChairOptionName.ChromeCoated, true);
        public static ChairOption Cross_ChromeCoated_400 = GenerateChairOption(ChairOptionType.Cross, ChairOptionName.ChromeCoated, CROSS_CHROME_400);
        public static ChairOption Cross_Wooden_Basic = GenerateChairOption(ChairOptionType.Cross, ChairOptionName.Wooden, true);
        public static ChairOption HeadRest_Angle_Basic = GenerateChairOption(ChairOptionType.HeadRest, ChairOptionName.HeadrestAngle, true);
        public static ChairOption HeadRest_Angle_400 = GenerateChairOption(ChairOptionType.HeadRest, ChairOptionName.HeadrestAngle, HEADREST_ANGLE_400);
        public static ChairOption HeadRest_AngleHeight_Basic = GenerateChairOption(ChairOptionType.HeadRest, ChairOptionName.HeadrestAngleHeight, true);
        public static ChairOption HeadRest_AngleHeight_600 = GenerateChairOption(ChairOptionType.HeadRest, ChairOptionName.HeadrestAngleHeight, HEADREST_ANGLE_HEIGHT_600);
        public static ChairOption HeadRest_AngleHeight_500 = GenerateChairOption(ChairOptionType.HeadRest, ChairOptionName.HeadrestAngleHeight, HEADREST_ANGLE_HEIGHT_500);
        public static ChairOption HeadRest_AngleHeight_400 = GenerateChairOption(ChairOptionType.HeadRest, ChairOptionName.HeadrestAngleHeight, HEADREST_ANGLE_HEIGHT_400);
        public static ChairOption Mechanism_Slander_Basic = GenerateChairOption(ChairOptionType.Mechanism, ChairOptionName.MechanismSlander, true);
        public static ChairOption Mechanism_Basic_Basic = GenerateChairOption(ChairOptionType.Mechanism, ChairOptionName.MechanismBasic, true);
        public static ChairOption Mechanism_RingBase_400 = GenerateChairOption(ChairOptionType.Mechanism, ChairOptionName.MechanismRing, MECHANISM_RING_BASE_400);
        public static ChairOption Mechanism_StopSupport_150 = GenerateChairOption(ChairOptionType.Mechanism, ChairOptionName.MechanismStop, MECHANISM_STOP_SUPPORT_150);
        public static ChairOption Onvay_StitchDesign_Basic = GenerateChairOption(ChairOptionType.Onvay, ChairOptionName.OnvayDesign, true);
        public static ChairOption Onvay_StitchDesign_1200 = GenerateChairOption(ChairOptionType.Onvay, ChairOptionName.OnvayDesign, ONVAY_STITCH_1200);
        public static ChairOption Onvay_StitchFashion_1200 = GenerateChairOption(ChairOptionType.Onvay, ChairOptionName.OnvayFashion, ONVAY_STITCH_1200);
        public static ChairOption Onvay_StitchQuatro_1200 = GenerateChairOption(ChairOptionType.Onvay, ChairOptionName.OnvayQuatro, ONVAY_STITCH_1200);
        public static ChairOption Onvay_StitchAristo_Basic = GenerateChairOption(ChairOptionType.Onvay, ChairOptionName.OnvayAristo, true);
        public static ChairOption Onvay_StitchZeta_1200 = GenerateChairOption(ChairOptionType.Onvay, ChairOptionName.OnvayZeta, ONVAY_STITCH_1200);
        public static ChairOption Onvay_Swaroski_1500 = GenerateChairOption(ChairOptionType.Onvay, ChairOptionName.OnvaySwarovski, ONVAY_SWAROVSKI_1500);
        public static ChairOption Onvay_Swaroski_1200 = GenerateChairOption(ChairOptionType.Onvay, ChairOptionName.OnvaySwarovski, ONVAY_SWAROVSKI_1200);
        public static ChairOption Onvay_logo_700 = GenerateChairOption(ChairOptionType.Onvay, ChairOptionName.OnvayLogo, ONVAY_LOGO_700);
        public static ChairOption Upholstery_Leather_5200 = GenerateChairOption(ChairOptionType.Upholstery, ChairOptionName.UpholsteryLeather, UPHOLSTERY_LEATHER_5200);
        public static ChairOption Upholstery_Leather_2500 = GenerateChairOption(ChairOptionType.Upholstery, ChairOptionName.UpholsteryLeather, UPHOLSTERY_LEATHER_2500);
        public static ChairOption Upholstery_Leather_2000 = GenerateChairOption(ChairOptionType.Upholstery, ChairOptionName.UpholsteryLeather, UPHOLSTERY_LEATHER_2000);
        public static ChairOption Upholstery_Leather_1700 = GenerateChairOption(ChairOptionType.Upholstery, ChairOptionName.UpholsteryLeather, UPHOLSTERY_LEATHER_1700);
        public static ChairOption Upholstery_PerfLeather_1200 = GenerateChairOption(ChairOptionType.Upholstery, ChairOptionName.UpholsteryPerfEcoLeather, UPHOLSTERY_PERF_LEATHER_1200);
        public static ChairOption Upholstery_PerfLeather_600 = GenerateChairOption(ChairOptionType.Upholstery, ChairOptionName.UpholsteryPerfEcoLeather, UPHOLSTERY_PERF_LEATHER_600);
        public static ChairOption Upholstery_Antara_Basic = GenerateChairOption(ChairOptionType.Upholstery, ChairOptionName.UpholsteryEcoLeather, true);

        private static ChairOption GenerateChairOption(string type, string name, int price)
        {
            return GenerateChairOption(type, name, false, price);
        }

        private static ChairOption GenerateChairOption(string type, string name, bool isBasic, int? price = null)
        {
            return new ChairOption
            {
                Name = name,
                Type = type,
                IsBasic = isBasic,
                Price = price
            };
        }
    }
}