using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EleniGeorge.Models.ShoppingBag
{
    public class ShoppingBagModel
    {
        private IEnumerable<GalleryItem> _itmes;

        public AccountModel account { get; set; }

        public ShoppingBagModel(string clientID)
        {
            // get item from database var clientID

            _itmes = new List<GalleryItem>()
            {
                new GalleryItem() { Name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/01.jpg", Price = 99.88},
                new GalleryItem() { Name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/02.jpg", Price = 99.88},
                new GalleryItem() { Name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/03.jpg", Price = 99.88},
                new GalleryItem() { Name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/04.jpg", Price = 99.88},
                new GalleryItem() { Name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/05.jpg", Price = 99.88},
                new GalleryItem() { Name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/06.jpg", Price = 99.88},
                new GalleryItem() { Name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/08.jpg", Price = 99.88},
                new GalleryItem() { Name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/09.jpg", Price = 99.88},
                new GalleryItem() { Name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/10.jpg", Price = 99.88},
                new GalleryItem() { Name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/11.jpg", Price = 99.88},
                new GalleryItem() { Name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/12.jpg", Price = 99.88},
                new GalleryItem() { Name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/13.jpg", Price = 99.88},
                new GalleryItem() { Name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/14.jpg", Price = 99.88},
                new GalleryItem() { Name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/15.jpg", Price = 99.88},
                new GalleryItem() { Name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/16.jpg", Price = 99.88},
                new GalleryItem() { Name = @"Alfred Test", ImgUrl = @"~/Images/TestImages/17.jpg", Price = 99.88},
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