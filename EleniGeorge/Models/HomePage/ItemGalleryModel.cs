using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EleniGeorge.Entity;

namespace EleniGeorge.Models
{
    public class ItemGalleryModel
    {
        public IEnumerable<GalleryItem> Items { get; set; }

        public ItemGalleryModel(IEnumerable<GalleryItem> items)
        {
            this.Items = items;
        }

        public ItemGalleryModel(int skip = 0, int step = 20)
        {
            using (var data = new TTDBEntities())
            {
                Items = (from it in data.Item
                         orderby it.SellStartDate
                         select new GalleryItem()
                         {
                             Name = it.Name,
                             ImgUrl = it.ItemPicture.FirstOrDefault(x => x.IsDefault).Picture.LargePictureAddress,
                             Price = it.ListPrice.HasValue ? it.ListPrice.Value : 0.0

                         }).Skip(skip).Take(step).ToList();
            }
        }
    }
}