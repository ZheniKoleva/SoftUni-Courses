function extensibleObject() {
    let proto = {};
    let extObj = Object.create(proto);

    extObj.extend = function (template) {
        for (const key in template) {
            if (typeof template[key] === 'function') {
                let proto = Object.getPrototypeOf(this);
                proto[key] = template[key];
            } else {
                this[key] = template[key];
            }
        }
    }

    return extObj;
}

const myObj = extensibleObject();
const template = {
    extensionMethod: function () { },
    extensionProperty: 'someString'
}
myObj.extend(template); 
  
    