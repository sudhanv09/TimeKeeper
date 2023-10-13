<script lang="ts">
	import { page } from "$app/stores";

    async function handleCheckout() {
        const checkout = await fetch('http://localhost:5145/user/checkout', {
            $page.params.slug,
        })
    }
</script>

<button class="btn variant-filled-primary"> Check-Out </button>