using KSEPM.Web.Database.Repositories;

namespace KSEPM.Web.Database
{
    public interface IKSEPMRepository
    {
        ChairRepository Chairs { get; }
        ChairOptionRepository ChairOptions { get; }
        ChairLineRepository ChairLines { get; }
        SellRepository Sells { get; }
        SellPointRepository SellPoints { get; }
        UserCallbackRepository UserCallbacks { get; }
    }
}
