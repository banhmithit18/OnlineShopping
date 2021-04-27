
$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "http://localhost:8085/api/products",

        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //alert(JSON.stringify(data));
            $.each(data, function (i, item) {
              
                var data = ' <div class="product">' +
                    '<div class="imgbox">'+
                '<img src="../img/gucci-shirt-white.png" />' +
                    '</div>' +
                    '<div class="details">' +
                    "<h2>" + item.brand + "<br /><span> Men's Design T-shirt </span> </h2>" +
                    '<div class="price"> $999</div>' +
                    '<label> Sizes </label>' +
                    '<ul>' +
                    '<li><span> S </span></li>' +
                    '<li><span> M </span></li>' +
                    '<li><span> L </span></li>' +
                    '</ul>' +
                    '<label> Colors </label>' +
                    '<div class="color-wrap">' +
                    '<ul class="colors">' +
                    '<li data-color="#FF0000" data-src="../img/gucci-shirt-red.png"></li>' +
                    '<li class="active" data-color="#FFF" data-src="../img/gucci-shirt-white.png"></li>' +
                    '<li data-color="#000000" data-src="../img/gucci-shirt-black.png"></li>' +
                    '</ul>' +
                    '</div>' +
                    '<a href="#"> Add To Cart </a>' +
                    '</div>' +
                    '</div>';
              

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