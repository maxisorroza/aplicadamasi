class SideNav {

    constructor() {

        this.showButtonEL = document.querySelector('.showIconMenu');
        this.hideButtonEL = document.querySelector('.hideIconMenu');
        this.sideNavEl = document.querySelector('.contenedorNumero1');
        this.sideNavConteinerEl = document.querySelector('.contenedorNumero2');

        this.showSideNav = this.showSideNav.bind(this);  /*volver a leer de bind que me re olvide que hacia esto*/
        this.hideSideNav = this.hideSideNav.bind(this);  /*volver a leer de bind que me re olvide que hacia esto*/
        this.blockClicks = this.blockClicks.bind(this);  /*volver a leer de bind que me re olvide que hacia esto*/

        this.addEventListeners()

    }

    addEventListeners() {

        this.showButtonEL.addEventListener('click', this.showSideNav);
        this.hideButtonEL.addEventListener('click', this.hideSideNav);
        this.sideNavEl.addEventListener('click', this.hideSideNav);
        this.sideNavConteinerEl.addEventListener('click', this.blockClicks);
    }

    blockClicks(evt) {

        evt.stopPropagation();
    }

    showSideNav() {

        this.sideNavEl.classList.add('contenedorNumero1--visible');
    }

    hideSideNav() {

        this.sideNavEl.classList.remove('contenedorNumero1--visible');
    }

}

new SideNav();