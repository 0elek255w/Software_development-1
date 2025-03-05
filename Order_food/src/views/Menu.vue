<template>
  <div class="container mt-4">
    <h1 class="text-center mb-4">Меню</h1>

    <div class="row">
      <div class="col-md-4" v-for="item in menuItems" :key="item.id">
        <div class="card">
          <img :src="item.image" class="card-img-top" :alt="item.name">
          <div class="card-body text-center">
            <h5 class="card-title">{{ item.name }}</h5>
            <p class="card-text">{{ item.price }} ₽</p>
            <button class="btn btn-primary" @click="addToCart(item)">В корзину</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      menuItems: [
        { id: 1, name: "Пепперони", price: 599, image: "pizza.jpg" },
        { id: 2, name: "Калифорния", price: 499, image: "sushi.jpg" },
        { id: 3, name: "Кола", price: 149, image: "cola.jpg" },
      ],
    };
  },
  methods: {
    addToCart(item) {
      console.log(`Добавлено в корзину: ${item.name}`);
    },
  },
};
</script>

<style scoped>
.card img {
  height: 200px;
  object-fit: cover;
}
</style>
