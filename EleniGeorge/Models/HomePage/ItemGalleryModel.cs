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
            //_itmes = new List<GalleryItem>()
            //{
            //    new GalleryItem() { name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/01.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/02.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/03.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/04.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/05.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/06.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/08.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/09.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/10.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/11.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/12.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/13.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/14.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/15.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/16.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/17.jpg", price = 99.88},
            //};

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