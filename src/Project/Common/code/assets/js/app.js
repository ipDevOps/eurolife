import Vue from 'vue';
import Panel from './components/Panel';
import PanelGroup from './components/PanelGroup';
import CoveragesAccordion from './components/CoveragesAccordion';
import Fragment from 'vue-fragment';

Vue.use(Fragment.Plugin);

Vue.component('app-panel', Panel);
Vue.component('app-panel-group', PanelGroup);
Vue.component('app-coverages-accordion', CoveragesAccordion);

const app = new Vue({
  el: '#app'
});