
function SearchLogic() {
    this.brands = [];
    this.cats = [];
    this.sizes = [];
    this.colors = [];
    this.genders = [];
    this.lengths = [];
    this.input = "";
}

SearchLogic.prototype.toJson = function () {
    var innerData = new Object();
    innerData["brands"] = this.brands;
    innerData["cats"] = this.cats;
    innerData["sizes"] = this.sizes;
    innerData["colors"] = this.colors;
    innerData["lengths"] = this.lengths;
    innerData["genders"] = this.genders;
    innerData["input"] = this.input;

    var reVal = { "data": JSON.stringify(innerData) };
    return reVal;
};
SearchLogic.prototype.addColor = function (color) {
    this.colors.push(color);
};
SearchLogic.prototype.addGender = function(gender) {
    this.genders.push(gender);
};

SearchLogic.prototype.addLength = function (length) {
    this.lengths.push(length);
};

SearchLogic.prototype.addBrand = function (brand) {
    this.brands.push(brand);
};
SearchLogic.prototype.addCat = function (cat) {
    this.cats.push(cat);
};
SearchLogic.prototype.addSize = function (size) {
    this.sizes.push(size);
};
SearchLogic.prototype.setInputString = function (strInput) {
    this.input = strInput;
};
SearchLogic.prototype.reSet = function () {
    this.brands = [];
    this.cats = [];
    this.sizes = [];
    this.colors = [];
    this.genders = [];
    this.lengths = [];
    this.input = "";
};