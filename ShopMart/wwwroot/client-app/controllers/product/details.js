var ProductDetailController = function () {
    this.initialize = function () {
        registerEvents();
    }

    function registerEvents() {
        $('#btnAddToCart').on('click', function (e) {
            e.preventDefault();
            var id = parseInt($(this).data('id'));
            var colorId = parseInt($(this).data('ddlColorId'));
            var sizeId = parseInt($(this).data('ddlSizeId'));
            $.ajax({
                url: '/Cart/AddToCart',
                type: 'post',
                dataType: 'json',
                data: {
                    productId: id,
                    quantity: parseInt($('#txtQuantity').val()),
                    color: colorId,
                    size : sizeId
                },
                success: function () {
                    shopmart.notify('Product was added successful', 'success');
               
                }
            });
        });
    }
    function loadHeaderCart() {
        $("#headerCart").load("/AjaxContent/HeaderCart");
    }
}