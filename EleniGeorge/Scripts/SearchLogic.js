
function SearchLogic() {
    this.brands = [];
    this.cats = [];
    this.sizes = [];
    this.colors = [];
    this.input = "";
}

SearchLogic.prototype.toJson = function () {
    var innerData = new Object();
    innerData["brands"] = this.brands;
    innerData["cats"] = this.cats;
    innerData["sizes"] = this.sizes;
    innerData["colors"] = this.colors;
    innerData["input"] = this.input;

    var reVal = { "data": JSON.stringify(innerData) };
    return reVal;
}

SearchLogic.prototype.addColor = function (color) {
    this.colors.push(color)
}

SearchLogic.prototype.addBrand = function (brand) {
    this.brands.push(brand);
}

SearchLogic.prototype.addCat = function (cat) {
    this.cats.push(cat);
}

SearchLogic.prototype.addSize = function (size) {
    this.sizes.push(size);
}

SearchLogic.prototype.setInputString = function (strInput) {
    this.input = strInput;
}

SearchLogic.prototype.reSet = function () {
    this.brands = [];
    this.cats = [];
    this.sizes = [];
    this.colors = [];
    this.input = "";
}