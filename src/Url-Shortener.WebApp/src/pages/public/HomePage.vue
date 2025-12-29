<script setup lang="ts">
import HomeLayout from '@/components/home/HomeLayout.vue'
import HeroSection from '@/components/home/HeroSection.vue'
import FeatureCard from '@/components/home/FeatureCard.vue'
import { ref } from 'vue'

const features = ref([
  {
    icon: 'mdi:chart-timeline-variant',
    title: 'Advanced Analytics',
    description: 'Track every click and measure your success with our detailed analytics dashboard.'
  },
  {
    icon: 'mdi:link-variant-plus',
    title: 'Custom Branded Links',
    description: 'Create short links that reflect your brand with custom domains and aliases.'
  },
  {
    icon: 'mdi:shield-lock',
    title: 'Secure & Reliable',
    description: 'Our platform is built with security in mind, ensuring your links are always safe.'
  }
])
</script>

<template>
  <HomeLayout>
    <HeroSection 
      title="Shorten, Share, and Shine"
      subtitle="The only URL shortener you'll ever need. Create clean, memorable links and track their performance with ease."
    />

    <section id="features" class="features-section">
      <div class="features-container">
        <FeatureCard 
          v-for="(feature, index) in features"
          :key="index"
          :icon="feature.icon"
          :title="feature.title"
          :description="feature.description"
        />
      </div>
    </section>
  </HomeLayout>
</template>

<style scoped>
.features-section {
  padding: 60px 24px;
}

.features-container {
  max-width: 1200px;
  margin: 0 auto;
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
  gap: 24px;
}
</style>
