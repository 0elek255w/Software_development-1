<template>
  <div id="app">
    <header>
      <div class="header-container">
        <h1>Сервис заказа еды</h1>
        <div class="profile-container" @click="openModal">
          <img src="@/assets/user-avatar.png" alt="Профиль" class="profile-icon" />
        </div>
      </div>
    </header>

    <nav>
      <router-link to="/">Главная</router-link>
      <router-link to="/menu">Меню</router-link>
      <router-link to="/cart">Корзина</router-link>
    </nav>
    <router-view></router-view>

    <footer>
      <p>© 2025 Сервис заказа еды</p>
    </footer>

    <div v-if="isModalOpen" class="modal">
      <div class="modal-content">
        <span class="close" @click="closeModal">&times;</span>
        <h2>{{ isRegister ? 'Регистрация' : 'Вход' }}</h2>
        <p v-if="isRegister">Создайте аккаунт, чтобы заказывать еду быстрее</p>
        <p v-else>Войдите, чтобы оформить заказ</p>

        <input type="email" placeholder="Email" v-model="email" />
        <input type="password" placeholder="Пароль" v-model="password" />

        <button @click="isRegister ? register() : login()">
          {{ isRegister ? 'Зарегистрироваться' : 'Войти' }}
        </button>

        <p class="toggle-auth" @click="toggleAuthMode">
          {{ isRegister ? 'Уже есть аккаунт? Войти' : 'Нет аккаунта? Зарегистрироваться' }}
        </p>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      isModalOpen: false,
      isLoginMode: true, // Режим: вход или регистрация
      email: "",
      password: "",
    };
  },
  methods: {
    openModal() {
      this.isModalOpen = true;
    },
    closeModal() {
      this.isModalOpen = false;
    },
    toggleAuthMode() {
      this.isRegister = !this.isRegister;
    },
    async login() {
      try {
        const response = await axios.get(`https://localhost:7147/User/${this.email}?password=${this.password}`);
        alert(`Вход успешен: ${response.data.message}`);
        this.isModalOpen = false;
      } catch (error) {
        alert(`Ошибка: ${error.response ? error.response.data.message : error.message}`);
      }
    },
    async register() {
      try {
        const response = await axios.post(`https://localhost:7147/User/${this.email}?password=${this.password}`);
        alert(`Регистрация успешна: ${response.data.message}`);
        this.isModalOpen = false;
      } catch (error) {
        alert(`Ошибка: ${error.response ? error.response.data.message : error.message}`);
      }
    },
  }
}
;



</script>

<style>
nav {
  display: flex;
  gap: 20px;
  padding: 10px;
  background: #f8f9fa;
}

nav a {
  text-decoration: none;
  color: #007bff;
  font-weight: bold;
}

nav a.router-link-active {
  color: #ff5733;
}

.header-container {
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.profile-icon {
  width: 40px;
  height: 40px;
  border-radius: 50%;
  object-fit: cover;
  border: 2px solid #007bff;
}

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

.modal-content {
  background: white;
  padding: 20px;
  border-radius: 10px;
  text-align: center;
  width: 300px;
}

.close {
  position: absolute;
  top: 10px;
  right: 15px;
  font-size: 20px;
  cursor: pointer;
}

input {
  width: 100%;
  padding: 8px;
  margin: 10px 0;
  border: 1px solid #ccc;
  border-radius: 5px;
}

button {
  background: #007bff;
  color: white;
  padding: 10px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  width: 100%;
}

.toggle-auth {
  color: #007bff;
  cursor: pointer;
  margin-top: 10px;
}
</style>
