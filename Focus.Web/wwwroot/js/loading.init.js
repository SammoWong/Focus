function showLoading() {
    $('body').loading({
        loadingWidth: 120,
        title: '',
        name: 'loading',
        discription: '',
        direction: 'column',
        type: 'origin',
        // originBg:'#71EA71',
        originDivWidth: 40,
        originDivHeight: 40,
        originWidth: 6,
        originHeight: 6,
        smallLoading: false,
        loadingMaskBg: 'rgba(0,0,0,0.2)'
    });
}

function hideLoading() {
    removeLoading('loading');
}