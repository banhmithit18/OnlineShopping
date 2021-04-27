var currentLocation = 0;
var skip = 0;
var wherethefuckiam = 0;
var currentValue;
var firstTime = true;
$(document).ready(function () {
     $("#mySearch").on('keyup', function (e) {
         if (e.key === 'Enter' || e.keyCode === 13) {
             var value = $('#mySearch').val();
           
            firstTime = true;
            currentValue = value;
            wherethefuckiam = 5;
            skip = 0;
            currentLocation = 0;
            loadDataWhithSkip(skip, "search", value)
        }
    });
    var brand = [];
    $.ajax({
        type: "GET",
        url: "http://localhost:8085/api/brands",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var data;
            //alert(JSON.stringify(data));
            $.each(data, function (y, item2) {
                brand.push(item2.nameBrand)
            })
            for (var index = 0; index < brand.length; index++) {
                data = data + '<option>' + brand[index] + '</option>';
            }
            $("#sort-brand").append(data);
            brand = [];
        }
    });
    $.ajax({
        type: "GET",
        url: "http://localhost:8085/api/types",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var data;
            //alert(JSON.stringify(data));
            $.each(data, function (y, item2) {
                brand.push(item2.typeName)
            })
            for (var index = 0; index < brand.length; index++) {
                data = data + '<option>' + brand[index] + '</option>';
            }
            $("#sort-type").append(data);
            brand = [];
        }
    });
    $.ajax({
        type: "GET",
        url: "http://localhost:8085/api/categories",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var data;
            //alert(JSON.stringify(data));
            $.each(data, function (y, item2) {
                brand.push(item2.categoryName)
            })
            for (var index = 0; index < brand.length; index++) {
                data = data + '<option>' + brand[index] + '</option>';
            }
            $("#sort-category").append(data);
            brand = [];
        }
    });
    loadData();
  
});




$('#sort-brand').change(function () {
    
    var brandName = $('#sort-brand :selected').text();
    if (brandName == "All") {
        wherethefuckiam = 0;
        skip = 0;
        currentLocation = 0;
        loadData();
        firstTime = false

    }
    else {
        firstTime = true;
        currentValue = brandName;
        wherethefuckiam = 1;
        skip = 0;
        currentLocation = 0;
        loadDataWhithSkip(skip, "brand", brandName)
       
    }
        

})
$('#sort-type').change(function () {

    var typeName = $('#sort-type :selected').text();
    if (typeName == "All") {
        wherethefuckiam = 0;
        skip = 0;
        currentLocation = 0;
        loadData();
        firstTime = false


    }
    else {
        firstTime = true;
        currentValue = typeName;
        wherethefuckiam = 2;
        skip = 0;
        currentLocation = 0;
        loadDataWhithSkip(skip, "type", typeName);

    }
})
$('#sort-category').change(function () {
    var typeName = $('#sort-category :selected').text();
    if (typeName == "All") {
        wherethefuckiam = 0;
        skip = 0;
        currentLocation = 0;
        loadData();
        firstTime = false

    }
    else {
        firstTime = true;
        currentValue = typeName;
        wherethefuckiam = 3;
        skip = 0;
        currentLocation = 0;
        loadDataWhithSkip(skip, "category", typeName)

    }
})
$('#sort-price').change(function () {
    var typeName = $('#sort-price :selected').text();
    if (typeName == "All") {
        wherethefuckiam = 0;
        skip = 0;
        currentLocation = 0;
      loadData();
        firstTime = false
    }
    else {
        firstTime = true;
        currentValue = typeName;
        wherethefuckiam = 4;
        skip = 0;
        currentLocation = 0;
        loadDataWhithSkip(skip, "name", typeName)

    }
})
Document.getElementsByClassName("product-grid").addEventListener("scroll", myFunction);

function myFunction() {
    var doc = document.documentElement;
    var nextLocation = (window.pageYOffset || doc.scrollTop) - (doc.clientTop || 0)
    if (nextLocation - currentLocation > 1000 && nextLocation > 1000) {
        switch (wherethefuckiam) {
            case 0:
                skip = skip == 0 ? 1 : skip;
                loadDataWhithSkip(skip, "product", 0);
                skip++;
                break;
            case 1:
                loadDataWhithSkip(skip, "brand", currentValue)
                skip++;
                break;
            case 2:
                loadDataWhithSkip(skip, "type", currentValue)
                skip++;
                break;
            case 3:
                loadDataWhithSkip(skip, "category", currentValue)
                skip++;
                break;
            case 4:
                loadDataWhithSkip(skip, "name", currentValue)
                skip++;
                break;
            case 5:
                loadDataWhithSkip(skip, "search", currentValue)
                skip++;
                break;
        }
     
    }
}

function loadDataWhithSkip(skip, field, value) {
   
    var url;
    switch (field) {
        case "product":
            url = "http://localhost:8085/api/products/product/0/" + skip;
            
            break;
        case "name":
            value = value.replaceAll(/\$/g, '');
            value = value.replaceAll("\\s", "");
            console.log(value);
            url = "http://localhost:8085/api/products/name/" + value +"/" + skip;
            break;
        case "category":
            url = "http://localhost:8085/api/products/category/" + value + "/" + skip
            break;
        case "type":
            url = "http://localhost:8085/api/products/type/" + value + "/" + skip
            break;
        case "brand":
            url = "http://localhost:8085/api/products/brand/" + value + "/" + skip
            break;
        case "search":
            url = "http://localhost:8085/api/products/search/" + value + "/" + skip
            break;
    }

    $.ajax({
        type: "GET",
        url: url,

        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            var size = [];
            var color = [];
            var img = [];
            //alert(JSON.stringify(data));
            $.each(data, function (i, item) {

                $.ajax({
                    async: false,
                    type: "GET",
                    url: "http://localhost:8085/api/productinfoes/" + item.id,

                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {         

                        //alert(JSON.stringify(data));
                        $.each(data, function (y, item2) {
                            size.push(item2.size);
                            color.push(item2.color);
                            img.push(item2.productImage)
                        })
                    }
                });
                var data = ' <div class="product">' +
                    '<div class="imgbox">' +
                    '<img src="../img/gucci-shirt-white.png" />' +
                    '</div>' +
                    '<div class="details">' +
                    "<h2>" + item.brand + "<br /><span>" + item.name + "</span> </h2>" +
                    '<div class="price"> $' + item.price + '</div>' +
                    '<label> Sizes </label>' +
                    '<ul>';

                for (var index = 0; index < size.length; index++) {
                    data = data + '<li><span>' + size[index] + '</span></li>';
                }
                data = data +
                    '</ul>' +
                    '<label> Colors </label>' +
                    '<div class="color-wrap">' +
                    '<ul class="colors">';
                for (var index = 0; index < color.length; ++index) {
                    if (index == 0) {
                        data = data + '<li class="active" data-color=' + color[index] + ' data-src="' + img[index] + '"></li>';

                    }
                    else {
                        data = data + '<li data-color=' + color[index] + ' data-src="' + img[index] + '"></li>';

                    }

                }
                data = data +
                    '</ul>' +
                    '</div>' +
                    '<a href="#"> Add To Cart </a>' +
                    '</div>' +
                    '</div>';

                if (skip == 0 && firstTime == true) {
                    $(".product-grid").html(data);
                    firstTime = false;
                }
                else {
                    $(".product:last").after(data);
                    
                }
                $(document).ready(function () {
                    $(".color-wrap ul li").each(function (item) {
                        var color = $(this).attr("data-color");
                        $(this).css("backgroundColor", color);
                    })
                    $(".color-wrap ul li").each(function (item) {
                        $(this).click(function () {
                            $(this).parents(".product").find(".color-wrap ul li").removeClass("active")
                            $(this).addClass("active");

                            var imgsrc = $(this).attr("data-src");
                            $(this).parents(".product").find("img").attr("src", imgsrc);
                        })
                    })
                })
                size = [];
                color = [];
                img = [];

            }); //End of foreach Loop
            skip++;
            var doc = document.documentElement;
            var nextLocation = (window.pageYOffset || doc.scrollTop) - (doc.clientTop || 0);
            currentLocation = nextLocation;
            console.log(data)
        }, //End of AJAX Success function
      
        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function

    });
}

function loadData() {
    $.ajax({
        type: "GET",
        url: "http://localhost:8085/api/products",

        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            var size = [];
            var color = [];
            var img = [];
            var check = false;
            //alert(JSON.stringify(data));
            $.each(data, function (i, item) {

                $.ajax({
                    async: false,
                    type: "GET",
                    url: "http://localhost:8085/api/productinfoes/" + item.id,

                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        //alert(JSON.stringify(data));
                        $.each(data, function (y, item2) {
                            size.push(item2.size);
                            color.push(item2.color);
                            img.push(item2.productImage)
                        })
                    }
                });

                size = [...new Set(size)];
                var data = ' <div class="product">' +
                    '<div class="imgbox">' +
                    '<img src="../img/gucci-shirt-white.png" />' +
                    '</div>' +
                    '<div class="details">' +
                    "<h2>" + item.brand + "<br /><span>" + item.name + "</span> </h2>" +
                    '<div class="price"> $' + item.price + '</div>' +
                    '<label> Sizes </label>' +
                    '<ul>';

                for (var index = 0; index < size.length; index++) {
                    data = data + '<li><span>' + size[index] + '</span></li>';
                }
                data = data +
                    '</ul>' +
                    '<label> Colors </label>' +
                    '<div class="color-wrap">' +
                    '<ul class="colors">';
                for (var index = 0; index < color.length; ++index) {
                    if (index == 0) {
                        data = data + '<li class="active" data-color=' + color[index] + ' data-src="' + img[index] + '"></li>';

                    }
                    else {
                        data = data + '<li data-color=' + color[index] + ' data-src="' + img[index] + '"></li>';

                    }

                }
                data = data +
                    '</ul>' +
                    '</div>' +
                    '<a href="#"> Add To Cart </a>' +
                    '</div>' +
                    '</div>';
                if (check == false) {
                    $(".product-grid").html(data);
                    check = true;
                }
                else {
                    $(".product:last").after(data);
                }
                $(document).ready(function () {
                    $(".color-wrap ul li").each(function (item) {
                        var color = $(this).attr("data-color");
                        $(this).css("backgroundColor", color);
                    })
                    $(".color-wrap ul li").each(function (item) {
                        $(this).click(function () {
                            $(this).parents(".product").find(".color-wrap ul li").removeClass("active")
                            $(this).addClass("active");

                            var imgsrc = $(this).attr("data-src");
                            $(this).parents(".product").find("img").attr("src", imgsrc);
                        })
                    })
                })
                size = [];
                color = [];
                img = [];

            }); //End of foreach Loop
            console.log(data);
        }, //End of AJAX Success function

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function

    });
}

