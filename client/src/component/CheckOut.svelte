<script lang="ts">
	import { page } from "$app/stores";
    export let active: boolean

    const id = $page.params.slug;   
    const currTime = new Date().toISOString()        
    
    async function handleCheckout() {
        const response = await fetch('http://localhost:5145/staff/checkout', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ id, 'checkoutTime':currTime })
        })
    }
</script>

{#if !active}
	<button class="btn variant-filled-primary disabled:opacity-50 disabled:cursor-not-allowed disabled:brightness-100" on:click={handleCheckout}> Check-Out </button>
{:else}
	<button class="btn variant-filled-primary" on:click={handleCheckout}> Check-Out </button>
{/if}
