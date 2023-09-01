<script setup lang="ts">
import { onMounted } from "vue";
import { initFlowbite } from "flowbite";
import ProductFilter from "./ProductFilter.vue";
import ProductList from "./ProductList.vue";
import ProductPagination from "./ProductPagination.vue";
import ReadProductModal from "./ReadProductModal.vue";
import AddProductModal from "./AddProductModal.vue";

import UpdateProductModal from "./UpdateProductModal.vue";

onMounted(() => {
  initFlowbite();
});
</script>

<template>
  <section class="bg-gray-50 dark:bg-gray-900 p-3 sm:p-5">
    <div class="mx-auto max-w-screen-xl px-4 lg:px-12">
      <div
        class="bg-white dark:bg-gray-800 relative shadow-md sm:rounded-lg overflow-hidden"
      >
        <ProductFilter />
        <ProductList />
        <ProductPagination />
        <ReadProductModal />
        <AddProductModal />
        <UpdateProductModal />
      </div>
    </div>
  </section>
</template>
