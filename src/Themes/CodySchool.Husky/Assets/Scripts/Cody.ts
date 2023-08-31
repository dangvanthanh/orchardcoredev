import { ref } from "vue/dist/vue.esm-bundler.js";

export default {
  setup() {
    return {
      count: ref(0),
    };
  },
  template: '<button @click="count++">Count is: {{ count }}</button>',
};
