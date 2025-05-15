$(document).ready(() => {
    configurarSelect2()
})

function configurarSelect2() {
    $('.form-select').select2()

    $('.form-select').each(function () {
        $(this).select2({
            dropdownParent: $(this).parent()
        })
    })
}