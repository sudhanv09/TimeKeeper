<script lang="ts">
	import { page } from "$app/stores";

    async function handleCheckin() {
        const response = await fetch('http://localhost:5145/user/checkin', {
            $page.params.slug,
        })
    }
</script>

<button class="btn variant-filled-primary"> Check-In </button>