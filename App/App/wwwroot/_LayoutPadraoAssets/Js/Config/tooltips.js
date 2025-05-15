$(document).ready(() => {
    configurarTooltips()
})

function configurarTooltips() {
    $('[role="tooltip"]').remove()

    $('[data-bs-toggle="tooltip"]').tooltip({
        trigger: 'hover'
    })

    $('[data-bs-toggle="tooltip"]').on('click', function () {
        $(this).tooltip('hide')
    })
}