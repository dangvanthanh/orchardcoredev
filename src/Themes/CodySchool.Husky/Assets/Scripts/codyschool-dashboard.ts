import { createApp } from "vue/dist/vue.esm-bundler.js";
import Dashboard from "./features/Dashboard.vue";

window.initDashboard = function (element: string) {
  if (element) {
    const app = createApp({});
    app.component("Dashboard", Dashboard);
    app.mount(element);
  }
};
