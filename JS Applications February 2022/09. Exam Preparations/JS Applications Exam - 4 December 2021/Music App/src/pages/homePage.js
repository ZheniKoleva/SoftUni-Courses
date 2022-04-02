import { homeTemplate } from "./../templates/homeTemplate.js"; 

function getView(cntx) {
    cntx.renderView(homeTemplate());
}

export default {
    getView
}