function toggleFullscreen() {
    if (!document.fullscreenElement) {
        document.documentElement.requestFullscreen()
    } else if (document.exitFullscreen) {
        document.exitFullscreen()
    }
}

function toggleSidebar() {
    const sidebarSize = $('html').attr('sidebar-size')

    $('#sidebar').css('transform', 'translateX(0)')

    if (!sidebarSize) {
        $('html').attr('sidebar-size', 'small')
    } else if (sidebarSize == 'small') {
        $('html').removeAttr('sidebar-size')
    }
}