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
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"1", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"1", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"1", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"1", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"1", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"1", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"1", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"1", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"1", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"1", price = 99.88},
                new GalleryItem() { name = @"Alfred Test", imgUrl = @"1", price = 99.88},
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