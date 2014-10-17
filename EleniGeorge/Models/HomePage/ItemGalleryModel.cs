using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EleniGeorge.Entity;

namespace EleniGeorge.Models
{
    public class ItemGalleryModel
    {
        private IEnumerable<GalleryItem> _itmes;

        public ItemGalleryModel(IEnumerable<GalleryItem> items)
        {
            _itmes = items;
        }

        public ItemGalleryModel(int skip = 0, int step = 20)
        {
            //_itmes = new List<GalleryItem>()
            //{
            //    new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/01.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/02.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/03.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/04.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/05.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/06.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/08.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/09.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/10.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/11.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/12.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/13.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/14.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/15.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/16.jpg", price = 99.88},
            //    new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/17.jpg", price = 99.88},
            //};

            using (var data = new TTDBEntities())
            {
                _itmes = (from it in data.Item
                          orderby it.SellStartDate
                          select new GalleryItem()
                          {
                              name = it.Name,
                              imgUrl = it.ItemPicture.FirstOrDefault(x => x.IsDefault).Picture.LargePictureAddress,
                              price = it.ListPrice.HasValue ? it.ListPrice.Value : 0.0

                          }).Skip(skip).Take(step).ToList();
            }
        }

        public IEnumerable<GalleryItem> items
        {
            get
            {
                return _itmes;
            }
        }
    }
}