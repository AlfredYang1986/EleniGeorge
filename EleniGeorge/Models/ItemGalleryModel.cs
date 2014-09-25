using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EleniGeorge.Models
{
    public class GalleryItem
    {
        public string name;
        public string imgUrl;
        public double price;
    }

    public class ItemGalleryModel
    {
        private IEnumerable<GalleryItem> _itmes;

        public ItemGalleryModel()
        {
            _itmes = new List<GalleryItem>()
            {
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/01.jpg", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/02.jpg", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/03.jpg", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/04.jpg", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/05.jpg", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/06.jpg", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/08.jpg", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/09.jpg", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/10.jpg", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/11.jpg", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/12.jpg", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/13.jpg", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/14.jpg", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/15.jpg", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/16.jpg", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"~/Images/TestImages/17.jpg", price = 99.88},
            };
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