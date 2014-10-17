using KSEPM.Web.Database.Entities;
using KSEPM.Web.Database.Repositories;

namespace KSEPM.Web.Database
{
    public class KSEPMRepository : IKSEPMRepository
    {
        private KSEPMDbContext _context;
        public KSEPMRepository()
        {
            _context = new KSEPMDbContext();
        }

        private ChairRepository _chairRepository;
        public ChairRepository Chairs
        {
            get
            {
                if (_chairRepository == null)
                    _chairRepository = new ChairRepository(_context);
                return _chairRepository;
            }
        }

        private ChairOptionRepository _chairOptionRepository;
        public ChairOptionRepository ChairOptions
        {
            get
            {
                if (_chairOptionRepository == null)
                    _chairOptionRepository = new ChairOptionRepository(_context);
                return _chairOptionRepository;
            }
        }

        private ChairLineRepository _chairLineRepository;
        public ChairLineRepository ChairLines
        {
            get
            {
                if (_chairLineRepository == null)
                    _chairLineRepository = new ChairLineRepository(_context);
                return _chairLineRepository;
            }
        }

        private SellRepository _sellRepository;
        public SellRepository Sells
        {
            get
            {
                if (_sellRepository == null)
                    _sellRepository = new SellRepository(_context);
                return _sellRepository;
            }
        }

        private SellPointRepository _sellPointRepository;
        public SellPointRepository SellPoints
        {
            get
            {
                if (_sellPointRepository == null)
                    _sellPointRepository = new SellPointRepository(_context);
                return _sellPointRepository;
            }
        }

        private UserCallbackRepository _userCallbackRepository;
        public UserCallbackRepository UserCallbacks
        {
            get
            {
                if (_userCallbackRepository == null)
                    _userCallbackRepository = new UserCallbackRepository(_context);
                return _userCallbackRepository;
            }
        }
    }
}
