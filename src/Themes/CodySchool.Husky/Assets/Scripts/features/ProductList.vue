<script setup lang="ts">
import { onMounted } from "vue";
import useProduct from './useProduct'

const { products, getProducts, getProductById, deleteProduct } = useProduct()

onMounted(getProducts)

const removeProduct = (id: string) => {
  deleteProduct(id)
  getProducts()
} 
</script>

<template>
  <div class="overflow-x-auto">
    <table class="w-full text-sm text-left text-gray-500 dark:text-gray-400">
      <thead class="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
        <tr>
          <th scope="col" class="px-4 py-3">Product name</th>
          <th scope="col" class="px-4 py-3">Category</th>
          <th scope="col" class="px-4 py-3">Brand</th>
          <th scope="col" class="px-4 py-3">Description</th>
          <th scope="col" class="px-4 py-3">Price</th>
          <th scope="col" class="px-4 py-3">
            <span class="sr-only">Actions</span>
          </th>
        </tr>
      </thead>
      <tbody>
        <template v-for="product in products">
          <tr class="border-b dark:border-gray-700">
            <th scope="row" class="px-4 py-3 font-medium text-gray-900 whitespace-nowrap dark:text-white">
              {{ product.name }}
            </th>
            <td class="px-4 py-3">
              {{ product.category }}
            </td>
            <td class="px-4 py-3">
              {{ product.brand }}
            </td>
            <td class="px-4 py-3">
              {{ product.description }}
            </td>
            <td class="px-4 py-3">
              {{
                new Intl.NumberFormat("en-US", {
                  style: "currency",
                  currency: "USD",
                }).format(product.price)
              }}
            </td>
            <td class="px-4 py-3 flex items-center justify-end">
              <button :data-dropdown-toggle="`dropdown-${product.id}`"
                class="inline-flex items-center p-0.5 text-sm font-medium text-center text-gray-500 hover:text-gray-800 rounded-lg focus:outline-none dark:text-gray-400 dark:hover:text-gray-100"
                type="button">
                <svg class="w-5 h-5" aria-hidden="true" fill="currentColor" viewBox="0 0 20 20"
                  xmlns="http://www.w3.org/2000/svg">
                  <path
                    d="M6 10a2 2 0 11-4 0 2 2 0 014 0zM12 10a2 2 0 11-4 0 2 2 0 014 0zM16 12a2 2 0 100-4 2 2 0 000 4z" />
                </svg>
              </button>
              <div :id="`dropdown-${product.id}`"
                class="hidden z-10 w-44 bg-white rounded divide-y divide-gray-100 shadow dark:bg-gray-700 dark:divide-gray-600">
                <ul class="py-1 text-sm text-gray-700 dark:text-gray-200">
                  <li>
                    <a href="#" class="block py-2 px-4 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white"
                      data-modal-toggle="readProductModal" @click="getProductById(product.id)">
                      Show
                    </a>
                  </li>
                  <li>
                    <a href="#" class="block py-2 px-4 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white"
                      data-modal-toggle="updateProductModal" @click="getProductById(product.id)">
                      Edit
                    </a>
                  </li>
                </ul>
                <div class="py-1">
                  <a href="#"
                    class="block py-2 px-4 text-sm text-gray-700 hover:bg-gray-100 dark:hover:bg-gray-600 dark:text-gray-200 dark:hover:text-white"
                    @click="removeProduct(product.id)">
                    Delete
                  </a>
                </div>
              </div>
            </td>
          </tr>
        </template>
      </tbody>
    </table>
  </div>
</template>