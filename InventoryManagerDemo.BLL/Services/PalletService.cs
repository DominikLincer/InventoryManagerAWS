using InventoryManagerDemo.Client.Requests;
using InventoryManagerDemo.Database;
using InventoryManagerDemo.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace InventoryManagerDemo.BLL.Services
{
    public class PalletService
    {
        private readonly InventoryManagerContext _inventorManagerContext;

        public PalletService()
        {
            _inventorManagerContext = new InventoryManagerContext();
        }

        public void PlacePallet(PlacePalletRequest pallet)
        {
            if (pallet == null || pallet.Size == null)
            {
                throw new Exception("PlacePalletRequest is null");
            }

            var palletModel = new Pallet
            {
                IsPlaced = true,
                Size = new Size
                {
                    Heigh = pallet.Size.Height,
                    Length = pallet.Size.Length,
                    Width = pallet.Size.Width
                },
                Weight = pallet.Weight
            };

            _inventorManagerContext.Add(palletModel);
            _inventorManagerContext.SaveChanges();
        }

        public GetPalletResponse GetPallet(int palletId)
        {
            var pallet = _inventorManagerContext.Pallets
                .Include(x => x.Size)
                .SingleOrDefault(x => x.Id == palletId);

            if (pallet == null)
            {
                throw new ArgumentException($"Pallet: {palletId} does not exist");
            }

            TakeDownPallet(pallet);

            return new GetPalletResponse
            {
                Size = new SizeDTO
                {
                    Height = pallet.Size.Heigh,
                    Length = pallet.Size.Length,
                    Width = pallet.Size.Width
                },
                Weight = pallet.Weight
            };
        }

        private void TakeDownPallet(Pallet pallet)
        {
            pallet.IsPlaced = false;
            _inventorManagerContext.Update(pallet);
            _inventorManagerContext.SaveChanges();
        }
    }
}
