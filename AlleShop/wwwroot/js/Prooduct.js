var currentLocation = 0;
var skip = 1;

$(document).ready(function () {

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
                            color.push(item2.color);3u83
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
                  data= data+
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
});

Document.getElementsByClassName("product-grid").addEventListener("scroll", myFunction);
function myFunction() {
    var doc = document.documentElement;
    var nextLocation = (window.pageYOffset || doc.scrollTop) - (doc.clientTop || 0)
    if (nextLocation - currentLocation > 1000 && nextLocation > 1000) {
        console.log("load");
        $.ajax({
            type: "GET",
            url: "http://localhost:8085/api/products/skip/"+skip,

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

                    $(".product:last").after(data);                   
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
                currentLocation = nextLocation;
                skip++;
            }, //End of AJAX Success function

            failure: function (data) {
                alert(data.responseText);
            }, //End of AJAX failure function
            error: function (data) {
                alert(data.responseText);
            } //End of AJAX error function

        });
    }
}