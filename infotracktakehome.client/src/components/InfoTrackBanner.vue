<template>
    <div class="banner">
        <div class="image-container">
            <img src="/infoTrack.png" alt="InfoTrack Icon" class="banner-image" />
        </div>
    </div>
</template>

<style scoped>
    .banner {
        display: flex;
        justify-content: center;
        align-items: center;
        background: linear-gradient(to right, #0093E9, #80D0C7);
        padding: 20px;
    }

    .image-container {
        background-color: white;
        border-radius: 5%;
        padding: 20px; 
        display: flex;
        justify-content: center;
        align-items: center;
    }

    .banner-image {
        max-width: 100%;
        height: auto;
    }
</style>
