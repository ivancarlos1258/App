$(document).ready(() => {
    configureActiveLink()
    configureSidebarAccordions()
    setSidebarSize()
    window.addEventListener('resize', () => setSidebarSize(), true)
})

function configureActiveLink() {
    $('.itemSidebar a').each(function () {
        const isActiveLink = $(this).attr('href') == window.location.pathname
        if (isActiveLink) {
            $(this).addClass('isActive')
        }

        const accordionElement = $(this).closest('.accordionSidebar')
        if (isActiveLink && accordionElement) {
            accordionElement.addClass('isOpen')
            accordionElement.find('.setaAccordionSidebar').removeClass('bi-chevron-down')
            accordionElement.find('.setaAccordionSidebar').addClass('bi-chevron-up')
            accordionElement.find('.headerAccordionSidebar').addClass('isActive')
        }
    })
}

function configureSidebarAccordions() {
    $('.headerAccordionSidebar').on('click', e => {
        const accordionElement = $(e.target).closest('.accordionSidebar')
        const isOpen = accordionElement.hasClass('isOpen')

        const arrowElement = accordionElement.find('.setaAccordionSidebar')

        $('.accordionSidebar').removeClass('isOpen')
        $('.setaAccordionSidebar').removeClass('bi-chevron-up')
        $('.setaAccordionSidebar').addClass('bi-chevron-down')

        if (!isOpen) {
            accordionElement.addClass('isOpen')
            arrowElement.removeClass('bi-chevron-down')
            arrowElement.addClass('bi-chevron-up')
        }
    })
}

function setSidebarSize() {
    $('#sidebar').css('transform', 'translateX(0)')

    if (window.innerWidth < 600) {
        $('html').attr('sidebar-size', 'mobile')
        $('#sidebar').css('transform', 'translateX(-100%)')
    }
    else if (window.innerWidth >= 600 && window.innerWidth < 800) {
        $('html').attr('sidebar-size', 'small')
    }
    else if (window.innerWidth >= 800) {
        $('html').removeAttr('sidebar-size')
    }
}