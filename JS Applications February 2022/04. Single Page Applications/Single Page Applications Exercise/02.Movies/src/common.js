const viewSections = [...document.querySelectorAll('.view')];

function hideViews() {
    viewSections.forEach(x => x.style.display = 'none');
}

export function showView(section) {
    hideViews();
    section.style.display = 'block';
}

export function hasSession() {
    const session = sessionStorage.token;

    if(!session) {
        return null;
    }

    return JSON.parse(session);
}