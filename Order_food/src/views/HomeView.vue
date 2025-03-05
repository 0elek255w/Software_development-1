<template>
  <div class="home">
    <h1>Добро пожаловать на сайт заказа еды!</h1>
    <p>Выберите блюда из меню и оформите заказ.</p>
    <router-link to="/cart">Перейти в корзину</router-link> <!-- Кнопка для перехода в корзину -->
  </div>
</template>

<script>
export default {
  name: 'Home',
};
</script>

<style scoped>
.home {
  text-align: center;
  margin-top: 50px;
}
</style>
