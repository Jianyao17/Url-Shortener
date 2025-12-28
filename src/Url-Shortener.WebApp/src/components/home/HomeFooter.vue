<template>
  <footer class="home-footer">
    <div class="footer-container">
      <div class="footer-links">
        <a href="#">About Us</a>
        <a href="#">Terms of Service</a>
        <a href="#">Privacy Policy</a>
        <a href="#">Contact</a>
      </div>
      <p class="copyright">© {{ new Date().getFullYear() }} Shorty. All rights reserved.</p>
    </div>
  </footer>
</template>

<style scoped>
.home-footer {
  padding: 40px 24px;
  background-color: var(--neutral-100);
  border-top: 1px solid var(--neutral-200);
}
.dark .home-footer {
  background-color: var(--neutral-800);
  border-top: 1px solid var(--neutral-700);
}

.footer-container {
  max-width: 1200px;
  margin: 0 auto;
  text-align: center;
}

.footer-links {
  display: flex;
  justify-content: center;
  gap: 24px;
  margin-bottom: 20px;
}

.footer-links a {
  color: var(--neutral-600);
  text-decoration: none;
  font-weight: 500;
  transition: color 0.2s;
}
.dark .footer-links a {
  color: var(--neutral-400);
}

.footer-links a:hover {
  color: var(--primary-red-500);
}
.dark .footer-links a:hover {
  color: var(--primary-red-400);
}

.copyright {
  color: var(--neutral-500);
  font-size: 0.9rem;
}
.dark .copyright {
  color: var(--neutral-500);
}
</style>
