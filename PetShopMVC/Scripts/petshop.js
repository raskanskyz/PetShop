 $(document).ready(function () {
    LoadDataTables();
});

function clearTextArea() {
    $('textarea[name=comment]').val("");
}

$("#addAnimalSubmit").on("click", function () {
    var formInfo = $("#addAnimalFormInfo");
    catObject = {
        "CategoryId": $("#Category option:selected").val()
    };
    var model = formInfo.serialize() + '&' + $.param(catObject);
    $.ajax({
        url: $("#AddNewAnimal").val(),
        type: 'post',
        data: model,
        success: function () {
            new PNotify({
                title: "Successfully added " + $("#Name").val(),
                text: $("#Name").val() + " has been added to the system and can be viewed in list",
                type: 'success'
            });
            UpdateView(formInfo.find('input[name="Category.Name"]').val());
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("addAnimalSubmit: " + errorThrown);
        }
    });
});

$(function () {
    $.each($("#categoryList").children(), function (index, value) {
        if ($(this).val() != "0") {
            $(this).addClass("category-item");
        }
    });
});

$(function () {
    PNotify.prototype.options.styling = "bootstrap3";
});

$("#categoryList").on("change", function (e) {
    var select = e.target;
    var option = select.options[select.selectedIndex];
    if ($(option).hasClass('category-item')) {
        $.ajax({
            method: "POST",
            url: $("#GetAnimalsInCategory").val(),
            data: { categoryId: $("#categoryList option:selected").val() },
            success: function (content) {
                $("#animalListContainer").html(content);
                LoadDataTables();
            },
            error: function () {
                alert($(this).val());
            },
        });
    }
});

function UpdateView(categoryName) {
    $.post($("#GetAnimalsInCategoryByName").val(), { categoryName: categoryName })
    .done(function (data) {
        $("#animalListContainer").html(data);
    });
};

$(".edit-animal").on("click", function () {
    $.getJSON($("#AnimalDetailsJson").val(), { animalId: $(this).attr("id") }, function (data) {
        $.post($("#GetCategoryNameById").val(), { id: data.result.CategoryId }, function (data) {
            $("#updateCategoryName").val(data);
        });
        $("#AnimalId").val(data.result.AnimalId);
        $("#updateModalLabel").text("edit " + data.result.Name + "'s details");
        $("#updateName").val(data.result.Name);
        $("#updateAge").val(data.result.Age);
        $("#updatePictureName").val(data.result.PictureName);
        $("#updateDescription").val(data.result.Description);
        //TODO: update edit form details
        //TODO: refresh picture
    });
});

$("#editAnimalSubmit").on("click", function () {
    var formInfo = $("#editAnimalFormInfo");
    $.ajax({
        url: $("#UpdateAnimal").val(),
        type: 'post',
        data: formInfo.serialize(),
        success: function () {
            new PNotify({
                title: "Successfully edited " + $("#updateName").val() + "'s details",
                text: 'details have been updated in the system and are reflected systemwide',
                type: 'success'
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("addAnimalSubmit: " + errorThrown);
        }
    });
});

function LoadDataTables() {
    $("#petShopTable").DataTable();
    $("#commentsTable").DataTable();
}
