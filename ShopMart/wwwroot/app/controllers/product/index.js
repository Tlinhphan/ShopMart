var productController = function () {
    this.initialize = function () {
        loadCategories();
        loadData();
        registerEvents();
    }

    function registerEvents() {
        //todo: binding events to controls
        $('#ddlShowPage').on('change', function () {
            shopmart.configs.pageSize = $(this).val();
            shopmart.configs.pageIndex = 1;
            loadData(true);
        });

        $('#btnSearch').on('click', function () {
            loadData();
        });

        $('#txtKeyword').on('keypress', function (e) {
            if (e.which === 13) {
                loadData();
            }
        });
    }

    function loadCategories() {
        $.ajax({
            url: '/admin/product/GetAllCategories',
            dataType: 'json',
            success: function (response) {
                var render = "<option value=''>--Select category--</option>";
                $.each(response, function (i, item) {
                    
                    render += "<option value ='"+item.Id+"'>"+item.Name+"</option>"
                
                });

                $('#ddlCategorySearch').html(render);
            },

            error: function (status) {
                console.log(status);
                shopmart.notify('Cannot loading product category data', 'error');
            }

        });
    }

    function loadData(isPageChanged) {
        var template = $('#table-template').html();
        var render = "";
        $.ajax({
            type: 'GET',
            data: {
                categoryId: $('#ddlCategorySearch').val(),
                keyword: $('#txtKeyword').val(),
                page: shopmart.configs.pageIndex,
                pageSize: shopmart.configs.pageSize

            },

            url: '/admin/product/GetAllPaging',
            dataType: 'json',
            success: function (response) {
                console.log(response);
                $.each(response.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Name: item.Name,
                        Image: item.Image == null ? '<img src="/admin-side/images/user.png" width=25' : '<img src="' + item.Image + '" width=25 />',
                        CategoryName: item.ProductCategory.Name,
                        Price: shopmart.formatNumber(item.Price, 0),
                        CreatedDate: shopmart.dateTimeFormatJson(item.DateCreated),
                        Status: shopmart.getStatus(item.Status)
                    });

                    $('#lblTotalRecords').text(response.RowCount);

                    if (render != '') {
                        $('#tbl-content').html(render);
                    }
                    wrapPaging(response.RowCount, function () {
                        loadData();
                    }, isPageChanged);
                });
            },

            error: function (status) {
                console.log(status);
                shopmart.notify('Cannot loading data', 'error');
            }

        });
    }

    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / shopmart.configs.pageSize);

        //Unbind pagination if it existed or click change pagesize
        if ($('#paginationUL a').length === 0 || changePageSize === true) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData("twbs-pagination");
            $('#paginationUL').unbind("page");

        }

        //Bind Pagination Event
        $('#paginationUL').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: 'Đầu',
            prev: 'Trước',
            next: 'Tiếp',
            last: 'Cuối',
            onPageClick: function (event, p) {
                shopmart.configs.pageIndex = p;
                setTimeout(callBack(), 200);

            }

        });
    }
}