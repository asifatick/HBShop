using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HBShop.Models;

namespace HBShop.DAL
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        private UnitRepository _unitRepository;
        private BatchRepository _batchRepository;
        private ClientRepository _clientRepository;
        private StockReceivedRepository _stockReceivedRepository;
        private AccountMasterRepository _accountMasterRepository;
        private CountryRepository _countryRepository;
        private ItemRepository _itemRepository;
        private OrderDetailRepository _orderDetailRepository;
        private OrderMasterRepository _orderMasterRepository;
        private SupplierRepository _supplierRepository;
        private CategoryRepository _categoryRepository;

        public UnitRepository UnitRepo
        {
            get
            {
                if (this._unitRepository == null)
                {
                    this._unitRepository = new UnitRepository(context);
                }
                return _unitRepository;
            }
        }

        public BatchRepository BatchRepository
        {
            get
            {
                if (this._batchRepository == null)
                {
                    this._batchRepository = new BatchRepository(context);
                }
                return _batchRepository;
            }
        }

        public ClientRepository ClientRepo
        {
            get
            {
                if (this._clientRepository == null)
                {
                    this._clientRepository = new ClientRepository(context);
                }
                return _clientRepository;
            }
        }

        public StockReceivedRepository StockReceivedRepo
        {
            get
            {
                if (this._stockReceivedRepository == null)
                {
                    this._stockReceivedRepository = new StockReceivedRepository(context);
                }
                return _stockReceivedRepository;
            }
        }

        public AccountMasterRepository AccountMasterRepo
        {
            get
            {
                if (this._accountMasterRepository == null)
                {
                    this._accountMasterRepository = new AccountMasterRepository(context);
                }
                return _accountMasterRepository;
            }
        }

        public CountryRepository CountryRepo
        {
            get
            {
                if (this._countryRepository == null)
                {
                    this._countryRepository = new CountryRepository(context);
                }
                return _countryRepository;
            }
        }

        public ItemRepository ItemRepo
        {
            get
            {
                if (this._itemRepository == null)
                {
                    this._itemRepository = new ItemRepository(context);
                }
                return _itemRepository;
            }
        }


        public OrderDetailRepository OrderDetailRepo
        {
            get
            {
                if (this._orderDetailRepository == null)
                {
                    this._orderDetailRepository = new OrderDetailRepository(context);
                }
                return _orderDetailRepository;
            }
        }


        public OrderMasterRepository OrderMasterRepo
        {
            get
            {
                if (this._orderMasterRepository == null)
                {
                    this._orderMasterRepository = new OrderMasterRepository(context);
                }
                return _orderMasterRepository;
            }
        }

        public SupplierRepository SupplierRepo
        {
            get
            {
                if (this._supplierRepository == null)
                {
                    this._supplierRepository = new SupplierRepository(context);
                }
                return _supplierRepository;
            }
        }
        public CategoryRepository CategoryRepo
        {
            get
            {
                if (this._categoryRepository == null)
                {
                    this._categoryRepository = new CategoryRepository(context);
                }
                return _categoryRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}