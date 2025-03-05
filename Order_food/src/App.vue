<template>
   <div id="app">
    <header>
      <div class="header-container">
        <!-- Заголовок сайта -->
        <h1>Сервис заказа еды</h1>

        <!-- Аватарка -->
        <div class="profile-container" @click="openModal">
          <img src="@/assets/user-avatar.png" alt="Профиль" class="profile-icon" />
        </div>
      </div>
    </header>

    <!-- Навигация -->
    <nav>
      <router-link to="/">Главная</router-link>
      <router-link to="/menu">Меню</router-link>
      <router-link to="/cart">Корзина</router-link>
    </nav>
    <router-view></router-view>

    <footer>
      <p>© 2025 Сервис заказа еды</p>
    </footer>
       <!-- Модальное окно для входа -->
       <div v-if="isModalOpen" class="modal">
      <div class="modal-content">
        <span class="close" @click="closeModal">&times;</span>
        <h2>Вход на сайт</h2>
        <p>Подарим подарок на день рождения, сохраним адрес доставки и расскажем об акциях</p>
        <input type="tel" placeholder="Номер телефона" v-model="phoneNumber" />
        <button @click="login">Войти</button>
        <p class="privacy">
          Продолжая, вы соглашаетесь со сбором и обработкой персональных данных и <a href="#">пользовательским соглашением</a>
        </p>
        </div>
      </div>
  </div>
</template>

<script>
export default {
  name: "App",
  data() {
    return {
      isModalOpen: false, // Открыто ли модальное окно
      phoneNumber: "", // Поле для номера телефона
    };
  },
  methods: {
    openModal() {
      this.isModalOpen = true;
    },
    closeModal() {
      this.isModalOpen = false;
    },
    login() {
      alert(`Вход с номером: ${this.phoneNumber}`);
      this.isModalOpen = false;
    },
  },
};
</script>

<style>
/* Контейнер для аватарки */
.header-container {
  display: flex;
  align-items: center;
  justify-content: space-between; /* Заголовок влево, аватар вправо */
}

/* Аватарка */
.profile-icon {
  width: 40px;
  height: 40px;
  border-radius: 50%;
  object-fit: cover;
  border: 2px solid #007bff;
}

/* Стили для модального окна */
.modal {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: rgba(0, 0, 0, 0.5);
  display: flex;
  align-items: center;
  justify-content: center;
}

/* Контент модального окна */
.modal-content {
  background: white;
  padding: 20px;
  border-radius: 10px;
  text-align: center;
  width: 300px;
}

/* Кнопка закрытия */
.close {
  position: absolute;
  top: 10px;
  right: 15px;
  font-size: 20px;
  cursor: pointer;
}

/* Поле ввода */
input {
  width: 100%;
  padding: 8px;
  margin: 10px 0;
  border: 1px solid #ccc;
  border-radius: 5px;
}

/* Кнопка входа */
button {
  background: #007bff;
  color: white;
  padding: 10px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  width: 100%;
}

/* Стили для соглашения */
.privacy {
  font-size: 12px;
  color: #666;
  margin-top: 10px;
}

.privacy a {
  color: #007bff;
  text-decoration: none;
}
</style>