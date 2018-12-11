window.helpers = {
    setProperty: function (el, prop, value) {
        try {
            document.querySelector(el).style.setProperty(prop, value);
            return true;
        } catch (e) {
            console.log(e);
            return false;
        }
    }
};