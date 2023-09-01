import { useStorage } from "@vueuse/core";
import { IProduct } from "./Product";
import { ref } from "vue";

export default function useProduct() {
  const productsDefault: IProduct[] = [
    {
      id: "1",
      name: 'Apple iMac 27"',
      category: "PC",
      brand: "Apple",
      description: "300",
      price: 2999,
    },
    {
      id: "2",
      name: 'Apple iMac 20"',
      category: "PC",
      brand: "Apple",
      description: "200",
      price: 1499,
    },
    {
      id: "3",
      name: "Apple iPhone 14",
      category: "Phone",
      brand: "Apple",
      description: "1237",
      price: 999,
    },
  ];

  const products = useStorage("products", productsDefault);
  const productId = ref('')

  const getProducts = () => {
    return products;
  };

  const getProduct = (id: string) => {
    return products.value.find((product) => product.id === id);
  };

  const getProductById = (id: string) => {
    productId.value = id;
  };

  const addProduct = (product: IProduct) => {
    products.value.push(product);
  };

  const updateProduct = (id: string, newProduct: IProduct) => {
    products.value = products.value.map((product) => {
      if (product.id === id) {
        product = Object.assign(product, newProduct);
      }

      return product;
    });
  };

  const deleteProduct = (id: string) => {
    const index = products.value.findIndex((product) => product.id === id);
    products.value.splice(index, 1);
  };

  return {
    products,
    productId,
    getProducts,
    getProduct,
    getProductById,
    addProduct,
    updateProduct,
    deleteProduct,
  };
}
