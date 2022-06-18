
const initGigs = () => {
    let notificationsBadge = document.querySelector('.notification-count');

    function getData() {
        let result = '';
        fetch("/api/notifications")
            .then(res => res.json())
            .then(res => {
                result = res;
                notificationsBadge.textContent = res?.length;
            })
            .catch(err => new Error(`There was an error: ${err}`));
        return result
    }

    function render(obj) {
        if (obj) {
            return `
                       -> something here
                    `
        }
    }

    $('.notifications').popover({
        html: true,
        title: "notifications",
        content: () => 'this is the content',
        placement: 'bottom',
        //template: '<div class="popover notification-count" role="tooltip">ADPAUdhAUhdPIAUhdPIUAHDS</div>'
    });
}