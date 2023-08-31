import { createApp } from "vue/dist/vue.esm-bundler.js";
import Cody from "./Cody.vue";

declare global {
  interface Window {
    initApp: any;
  }
}

window.initApp = function (element: string) {
  if (element) {
    const app = createApp({});
    app.component("Cody", Cody);
    app.mount(element);
  }
};
