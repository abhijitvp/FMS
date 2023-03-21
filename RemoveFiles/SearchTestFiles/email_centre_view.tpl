
{#foreach $T as field}
<tr>
    <td class="checkbox_email" style="display:none"><input type="checkbox" class="case" name="case" value="{$T.field.id}" onclick="check();"/></td>
    <td onclick="viewEmailContent({$T.field.id}, '{$T.field.Status}');" {#if $T.field.Status == 'Bounced' || $T.field.Status == 'Invalid'} style='color: #FF0000'{#/if}>{$T.field.DateSentDisplay}</td>
    <td onclick="viewEmailContent({$T.field.id}, '{$T.field.Status}');">{$T.field.Category}</td>

    {#if $T.field.ClientId}
        <td class="editColumn"><a href="/#/crm/client_manager?mode=edit&id={$T.field.ClientId}">{$T.field.ClientName}</a></td>
    {#else}
        <td onclick="viewEmailContent({$T.field.id}, '{$T.field.Status}');">{$T.field.ClientName}</td>
    {#/if}

    {#if $T.field.SentTo.length >25} 
        <td onclick="viewEmailContent({$T.field.id}, '{$T.field.Status}');" {#if $T.field.Status == 'Bounced' || $T.field.Status == 'Invalid'} style='color: #FF0000'{#/if} title="{$T.field.SentTo}">{$T.field.SentTo.substr(0, 25)}...</td>
    {#else}
        <td onclick="viewEmailContent({$T.field.id}, '{$T.field.Status}');" {#if $T.field.Status == 'Bounced' || $T.field.Status == 'Invalid'} style='color: #FF0000'{#/if}>{$T.field.SentTo}</td>
    {#/if}
    <td onclick="viewEmailContent({$T.field.id}, '{$T.field.Status}');" {#if $T.field.Status == 'Bounced' || $T.field.Status == 'Invalid'} style='color: #FF0000'{#/if}>{$T.field.Subject}</td>
    <td onclick="viewEmailContent({$T.field.id}, '{$T.field.Status}');" {#if $T.field.Status == 'Bounced' || $T.field.Status == 'Invalid'} style='color: #FF0000'{#/if}>
		{#if $T.field.Status == 'Error'}
			<label style="cursor:pointer;" title="{$T.field.ErrorMessage}">{$T.field.Status}</label>
		{#else}	
			{$T.field.Status}
		{#/if}	
	</td>
    <td>
        {#if $T.field.Status == 'Bounced'}
            <a title="Resend Email" onclick="ResendEmail({$T.field.id},'s');" href="Javascript:void(0);"><img border="0" align="absmiddle" src="images/email.png"></a>
        {#/if}	
		{#if $T.field.Status == 'Invalid'}
            <a title="Resend Email" class="invalidEmailLink" style="display:none" onclick="ResendInvalidEmail({$T.field.id});" href="Javascript:void(0);"><img border="0" align="absmiddle" src="images/email.png"></a>
        {#/if}	
    </td> 
	<td class="deleteemail">
		{#if $T.field.Status == 'Bounced' || $T.field.Status == 'Error' || $T.field.Status == 'Invalid' }
            <a title="Delete" onclick="DeleteBouncedEmail({$T.field.id},'s');" href="Javascript:void(0);" class="deleteBox"></a>
        {#/if}	
	</td>      
</tr>

{#/for}
